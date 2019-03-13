using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    public float lerp;
    public float duration;

    private PostProcessVolume m_postProcessVolume;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void OnValidate()
    {
        m_postProcessVolume.profile = PostProcessProfileUtils.Lerp(postProcessProfileA, postProcessProfileB, lerp);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_postProcessVolume != null)
            {
                m_postProcessVolume.Transition(postProcessProfileA, duration);
            }
        }
    }
}
