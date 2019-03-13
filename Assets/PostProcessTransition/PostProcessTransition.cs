using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using System;

public class PostProcessTransition
{
    private Action m_onComplete;
    private PostProcessProfile m_tempProfile;
    private BloomTransition m_bloomTransition;
    private AmbientOcclusionTransition m_ambientOcclusionTransition;
    private AutoExposureTransition m_autoExposureTransition;
    private ChromaticAberrationTransition m_chromaticAberrationTransition;
    private Tweener m_tweener;

    public PostProcessTransition(PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration, Action onComplete)
    {
        m_onComplete = onComplete;
        m_tempProfile = UnityEngine.Object.Instantiate(postProcessVolume.profile);
        m_bloomTransition = new BloomTransition(postProcessVolume.profile, postProcessProfile, m_tempProfile);
        m_ambientOcclusionTransition = new AmbientOcclusionTransition(postProcessVolume.profile, postProcessProfile, m_tempProfile);
        m_autoExposureTransition = new AutoExposureTransition(postProcessVolume.profile, postProcessProfile, m_tempProfile);
        m_chromaticAberrationTransition = new ChromaticAberrationTransition(postProcessVolume.profile, postProcessProfile, m_tempProfile);
        postProcessVolume.profile = m_tempProfile;

        m_tweener = DOTween.To(OnTransitionUpdate, 0f, 1f, duration).OnComplete(OnTransitionComplete);
    }

    public void Destroy()
    {
        if(m_tweener != null)
        {
            m_tweener.Kill();
            m_tweener = null;
        }
    }

    private void OnTransitionUpdate(float value)
    {
        m_bloomTransition.Lerp(value);
        m_ambientOcclusionTransition.Lerp(value);
        m_autoExposureTransition.Lerp(value);
        m_chromaticAberrationTransition.Lerp(value);
    }

    private void OnTransitionComplete()
    {
        m_tweener = null;
        if(m_onComplete != null)
        {
            m_onComplete();
        }
    }
}
