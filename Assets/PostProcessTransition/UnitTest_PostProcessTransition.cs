using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile targetPostProcessProfile;
    public float duration;
    private PostProcessVolume m_postProcessVolume;
    private PostProcessTransition m_postProcessTransition;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTransitionComplete();
            m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, targetPostProcessProfile, duration, OnTransitionComplete);
        }
    }

    private void OnTransitionComplete()
    {
        if(m_postProcessTransition != null)
        {
            m_postProcessTransition.Destroy();
            m_postProcessTransition = null;
        }
    }
}
