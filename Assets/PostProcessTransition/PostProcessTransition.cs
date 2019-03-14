using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using System;

public class PostProcessTransition
{
    private const string TEMP_NAME = "PostProcessTransition";

    private PostProcessVolume m_postProcessVolumn;
    private PostProcessProfile m_fromPostProcessProfile;
    private PostProcessProfile m_toPostProcessProfile;
    private Action m_onComplete;
    private PostProcessProfile m_tempPostProcessProfile;
    
    private AmbientOcclusionTransition m_ambientOcclusionTransition;
    private AutoExposureTransition m_autoExposureTransition;
    private BloomTransition m_bloomTransition;
    private ChromaticAberrationTransition m_chromaticAberrationTransition;
    private ColorGradingTransition m_colorGradingTransition;
    private DepthOfFieldTransition m_depthOfFieldTransition;
    private GrainTransition m_grainTransition;
    private LensDistortionTransition m_lensDisstortionTransition;
    //private MotionBlurTransition m_motionBlurTransition;
    //private ScreenSpaceReflectionsTransition m_screenSpaceReflectionsTransition;
    //private VignetteTransition m_vignetteTransition;
    private Tweener m_tweener;

    public PostProcessTransition(PostProcessVolume postProcessVolume, PostProcessProfile toPostProcessProfile, float duration, Action onComplete)
    {
        m_postProcessVolumn = postProcessVolume;
        m_fromPostProcessProfile = m_postProcessVolumn.profile;
        m_toPostProcessProfile = toPostProcessProfile;
        m_onComplete = onComplete;
        m_tempPostProcessProfile = PostProcessTransitionUtils.CreateInstance();

        m_postProcessVolumn.profile = m_tempPostProcessProfile;

        m_ambientOcclusionTransition = new AmbientOcclusionTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_autoExposureTransition = new AutoExposureTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_bloomTransition = new BloomTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_chromaticAberrationTransition = new ChromaticAberrationTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_colorGradingTransition = new ColorGradingTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_depthOfFieldTransition = new DepthOfFieldTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_grainTransition = new GrainTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_lensDisstortionTransition = new LensDistortionTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        //m_motionBlurTransition = new MotionBlurTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        //m_screenSpaceReflectionsTransition = new ScreenSpaceReflectionsTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        //m_vignetteTransition = new VignetteTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);

        m_tweener = DOTween.To(Lerp, 0f, 1f, duration).OnComplete(OnComplete);
    }

    public void Lerp(float value)
    {
        UnityEngine.Debug.LogError(value);

        m_ambientOcclusionTransition.Lerp(value);
        m_autoExposureTransition.Lerp(value);
        m_bloomTransition.Lerp(value);
        m_chromaticAberrationTransition.Lerp(value);
        m_colorGradingTransition.Lerp(value);
        m_depthOfFieldTransition.Lerp(value);
        m_grainTransition.Lerp(value);
        m_lensDisstortionTransition.Lerp(value);
        //m_motionBlurTransition.Lerp(value);
        //m_screenSpaceReflectionsTransition.Lerp(value);
        //m_vignetteTransition.Lerp(value);
    }

    private void OnComplete()
    {
        m_postProcessVolumn.profile = m_toPostProcessProfile;
        m_tweener = null;

        if (m_onComplete != null)
        {
            m_onComplete();
        }
    }

    public void Destroy()
    {
        if(m_tweener != null)
        {
            m_tweener.Kill();
            m_tweener = null;
        }

        if(m_tempPostProcessProfile != null)
        {
            UnityEngine.Object.Destroy(m_tempPostProcessProfile);
            m_tempPostProcessProfile = null;
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

        if (m_bloomTransition != null)
        {
            m_bloomTransition.Destroy();
            m_bloomTransition = null;
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

        if (m_depthOfFieldTransition != null)
        {
            m_depthOfFieldTransition.Destroy();
            m_depthOfFieldTransition = null;
        }

        if (m_grainTransition != null)
        {
            m_grainTransition.Destroy();
            m_grainTransition = null;
        }

        if (m_lensDisstortionTransition != null)
        {
            m_lensDisstortionTransition.Destroy();
            m_lensDisstortionTransition = null;
        }

        //if (m_motionBlurTransition != null)
        //{
        //    m_motionBlurTransition.Destroy();
        //    m_motionBlurTransition = null;
        //}

        //if(m_screenSpaceReflectionsTransition != null)
        //{
        //    m_screenSpaceReflectionsTransition.Destroy();
        //    m_screenSpaceReflectionsTransition = null;
        //}

        //if(m_vignetteTransition != null)
        //{
        //    m_vignetteTransition.Destroy();
        //    m_vignetteTransition = null;
        //}
    }
}
