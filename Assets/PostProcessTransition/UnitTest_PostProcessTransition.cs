using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    [SerializeField] private PostProcessProfile m_targetPostProcessProfile;
    [SerializeField] private float m_duration;
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
            m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, m_targetPostProcessProfile, m_duration, OnTransitionComplete);
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
