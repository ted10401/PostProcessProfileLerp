using UnityEngine.Rendering.PostProcessing;

public class PostProcessTransition
{
    private const string TEMP_NAME = "PostProcessTransition";
    
    private AmbientOcclusionTransition m_ambientOcclusionTransition;
    private AutoExposureTransition m_autoExposureTransition;
    private BloomTransition m_bloomTransition;
    private ChromaticAberrationTransition m_chromaticAberrationTransition;
    private ColorGradingTransition m_colorGradingTransition;
    private DepthOfFieldTransition m_depthOfFieldTransition;
    private GrainTransition m_grainTransition;
    private LensDistortionTransition m_lensDisstortionTransition;
    private MotionBlurTransition m_motionBlurTransition;
    private ScreenSpaceReflectionsTransition m_screenSpaceReflectionsTransition;
    private VignetteTransition m_vignetteTransition;

    public PostProcessTransition(PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration)
    {
        PostProcessProfile from = postProcessVolume.profile;
        postProcessVolume.profile = UnityEngine.Object.Instantiate(from);
        postProcessVolume.profile.name = TEMP_NAME;

        m_ambientOcclusionTransition = new AmbientOcclusionTransition(from, postProcessProfile, postProcessVolume.profile);
        m_autoExposureTransition = new AutoExposureTransition(from, postProcessProfile, postProcessVolume.profile);
        m_bloomTransition = new BloomTransition(from, postProcessProfile, postProcessVolume.profile);
        m_chromaticAberrationTransition = new ChromaticAberrationTransition(from, postProcessProfile, postProcessVolume.profile);
        m_colorGradingTransition = new ColorGradingTransition(from, postProcessProfile, postProcessVolume.profile);
        m_depthOfFieldTransition = new DepthOfFieldTransition(from, postProcessProfile, postProcessVolume.profile);
        m_grainTransition = new GrainTransition(from, postProcessProfile, postProcessVolume.profile);
        m_lensDisstortionTransition = new LensDistortionTransition(from, postProcessProfile, postProcessVolume.profile);
        m_motionBlurTransition = new MotionBlurTransition(from, postProcessProfile, postProcessVolume.profile);
        m_screenSpaceReflectionsTransition = new ScreenSpaceReflectionsTransition(from, postProcessProfile, postProcessVolume.profile);
        m_vignetteTransition = new VignetteTransition(from, postProcessProfile, postProcessVolume.profile);
    }

    public void Lerp(float value)
    {
        m_ambientOcclusionTransition.Lerp(value);
        m_autoExposureTransition.Lerp(value);
        m_bloomTransition.Lerp(value);
        m_chromaticAberrationTransition.Lerp(value);
        m_colorGradingTransition.Lerp(value);
        m_depthOfFieldTransition.Lerp(value);
        m_grainTransition.Lerp(value);
        m_lensDisstortionTransition.Lerp(value);
        m_motionBlurTransition.Lerp(value);
        m_screenSpaceReflectionsTransition.Lerp(value);
        m_vignetteTransition.Lerp(value);
    }

    public void Destroy()
    {
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

        if(m_lensDisstortionTransition != null)
        {
            m_lensDisstortionTransition.Destroy();
            m_lensDisstortionTransition = null;
        }

        if(m_motionBlurTransition != null)
        {
            m_motionBlurTransition.Destroy();
            m_motionBlurTransition = null;
        }

        if(m_screenSpaceReflectionsTransition != null)
        {
            m_screenSpaceReflectionsTransition.Destroy();
            m_screenSpaceReflectionsTransition = null;
        }

        if(m_vignetteTransition != null)
        {
            m_vignetteTransition.Destroy();
            m_vignetteTransition = null;
        }
    }
}
