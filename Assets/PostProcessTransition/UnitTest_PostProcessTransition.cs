using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    public float duration;

    private PostProcessVolume m_postProcessVolume;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(m_postProcessVolume != null)
            {
                m_postProcessVolume.Transition(postProcessProfileA, duration);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (m_postProcessVolume != null)
            {
                m_postProcessVolume.Transition(postProcessProfileB, duration);
            }
        }
    }
}
