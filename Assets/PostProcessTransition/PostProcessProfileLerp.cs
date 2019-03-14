using UnityEngine.Rendering.PostProcessing;

public class PostProcessProfileLerp
{
    private const string TEMP_NAME = "PostProcessProfileLerp";

    private PostProcessProfile m_fromPostProcessProfile;
    private PostProcessProfile m_toPostProcessProfile;
    private PostProcessProfile m_tempPostProcessProfile;
    
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

    public PostProcessProfileLerp(PostProcessProfile a, PostProcessProfile b)
    {
        m_fromPostProcessProfile = a;
        m_toPostProcessProfile = b;
        m_tempPostProcessProfile = UnityEngine.ScriptableObject.CreateInstance<PostProcessProfile>();
        m_tempPostProcessProfile.name = TEMP_NAME;

        m_ambientOcclusionTransition = new AmbientOcclusionTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_autoExposureTransition = new AutoExposureTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_bloomTransition = new BloomTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_chromaticAberrationTransition = new ChromaticAberrationTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_colorGradingTransition = new ColorGradingTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_depthOfFieldTransition = new DepthOfFieldTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_grainTransition = new GrainTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_lensDisstortionTransition = new LensDistortionTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_motionBlurTransition = new MotionBlurTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_screenSpaceReflectionsTransition = new ScreenSpaceReflectionsTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_vignetteTransition = new VignetteTransition(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
    }

    ~PostProcessProfileLerp()
    {
        UnityEngine.Debug.LogError("~PostProcessProfileLerp");

        m_fromPostProcessProfile = null;
        m_toPostProcessProfile = null;
        m_tempPostProcessProfile = null;

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

        if (m_motionBlurTransition != null)
        {
            m_motionBlurTransition.Destroy();
            m_motionBlurTransition = null;
        }

        if (m_screenSpaceReflectionsTransition != null)
        {
            m_screenSpaceReflectionsTransition.Destroy();
            m_screenSpaceReflectionsTransition = null;
        }

        if (m_vignetteTransition != null)
        {
            m_vignetteTransition.Destroy();
            m_vignetteTransition = null;
        }
    }

    public PostProcessProfile Lerp(float t)
    {
        m_ambientOcclusionTransition.Lerp(t);
        m_autoExposureTransition.Lerp(t);
        m_bloomTransition.Lerp(t);
        m_chromaticAberrationTransition.Lerp(t);
        m_colorGradingTransition.Lerp(t);
        m_depthOfFieldTransition.Lerp(t);
        m_grainTransition.Lerp(t);
        m_lensDisstortionTransition.Lerp(t);
        m_motionBlurTransition.Lerp(t);
        m_screenSpaceReflectionsTransition.Lerp(t);
        m_vignetteTransition.Lerp(t);

        return m_tempPostProcessProfile;
    }
}
