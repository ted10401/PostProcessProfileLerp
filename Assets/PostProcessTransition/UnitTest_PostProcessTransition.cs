using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    [Range(0f, 1f)]
    public float lerp;

    private PostProcessVolume m_postProcessVolume;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void OnValidate()
    {
        if(m_postProcessVolume == null)
        {
            m_postProcessVolume = GetComponent<PostProcessVolume>();
        }

        if(m_postProcessVolume == null)
        {
            return;
        }

        if(postProcessProfileA == null || postProcessProfileB == null)
        {
            return;
        }

        m_postProcessVolume.profile = PostProcessProfileUtils.Lerp(postProcessProfileA, postProcessProfileB, lerp);
    }
}
