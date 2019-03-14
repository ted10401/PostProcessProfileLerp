using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    public float duration;

    private PostProcessVolume m_postProcessVolume;
    private PostProcessTransition m_postProcessTransition;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnTransitionComplete();
            m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, postProcessProfileA, duration, OnTransitionComplete);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnTransitionComplete();
            m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, postProcessProfileB, duration, OnTransitionComplete);
        }
    }

    private void OnTransitionComplete()
    {
        if (m_postProcessTransition != null)
        {
            m_postProcessTransition.Destroy();
            m_postProcessTransition = null;
        }
    }
}
