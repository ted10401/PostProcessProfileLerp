using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using System;

public class PostProcessTransition
{
    private Action m_onComplete;
    private AmbientOcclusionTransition m_ambientOcclusionTransition;
    private AutoExposureTransition m_autoExposureTransition;
    private BloomTransition m_bloomTransition;
    private ChromaticAberrationTransition m_chromaticAberrationTransition;
    private ColorGradingTransition m_colorGradingTransition;
    private DepthOfFieldTransition m_depthOfFieldTransition;
    private GrainTransition m_grainTransition;
    private Tweener m_tweener;

    public PostProcessTransition(PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration)
    {
        PostProcessProfile from = postProcessVolume.profile;
        postProcessVolume.profile = UnityEngine.Object.Instantiate(from);

        m_ambientOcclusionTransition = new AmbientOcclusionTransition(from, postProcessProfile, postProcessVolume.profile);
        m_autoExposureTransition = new AutoExposureTransition(from, postProcessProfile, postProcessVolume.profile);
        m_bloomTransition = new BloomTransition(from, postProcessProfile, postProcessVolume.profile);
        m_chromaticAberrationTransition = new ChromaticAberrationTransition(from, postProcessProfile, postProcessVolume.profile);
        m_colorGradingTransition = new ColorGradingTransition(from, postProcessProfile, postProcessVolume.profile);
        m_depthOfFieldTransition = new DepthOfFieldTransition(from, postProcessProfile, postProcessVolume.profile);
        m_grainTransition = new GrainTransition(from, postProcessProfile, postProcessVolume.profile);

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
        m_colorGradingTransition.Lerp(value);
        m_depthOfFieldTransition.Lerp(value);
        m_grainTransition.Lerp(value);
    }

    private void OnTransitionComplete()
    {
        m_tweener = null;

        if(m_bloomTransition != null)
        {
            m_bloomTransition.Destroy();
            m_bloomTransition = null;
        }

        if (m_ambientOcclusionTransition != null)
        {
            m_ambientOcclusionTransition.Destroy();
            m_ambientOcclusionTransition = null;
        }

        if (m_autoExposureTransition != null)
        {
            m_autoExposureTransition.Destroy();
            m_autoExposureTransition = null;
        }

        if (m_chromaticAberrationTransition != null)
        {
            m_chromaticAberrationTransition.Destroy();
            m_chromaticAberrationTransition = null;
        }

        if (m_colorGradingTransition != null)
        {
            m_colorGradingTransition.Destroy();
            m_colorGradingTransition = null;
        }

        if(m_depthOfFieldTransition != null)
        {
            m_depthOfFieldTransition.Destroy();
            m_depthOfFieldTransition = null;
        }

        if(m_grainTransition != null)
        {
            m_grainTransition.Destroy();
            m_grainTransition = null;
        }
    }
}
