using UnityEngine.Rendering.PostProcessing;

public class PostProcessProfileLerp
{
    private const string TEMP_NAME = "PostProcessProfileLerp";

    private PostProcessProfile m_fromPostProcessProfile;
    private PostProcessProfile m_toPostProcessProfile;
    private PostProcessProfile m_tempPostProcessProfile;
    
    private AmbientOcclusionLerp m_ambientOcclusionTransition;
    private AutoExposureLerp m_autoExposureTransition;
    private BloomLerp m_bloomTransition;
    private ChromaticAberrationLerp m_chromaticAberrationTransition;
    private ColorGradingLerp m_colorGradingTransition;
    private DepthOfFieldLerp m_depthOfFieldTransition;
    private GrainLerp m_grainTransition;
    private LensDistortionLerp m_lensDisstortionTransition;
    private MotionBlurLerp m_motionBlurTransition;
    private ScreenSpaceReflectionsLerp m_screenSpaceReflectionsTransition;
    private VignetteLerp m_vignetteTransition;

    public PostProcessProfileLerp(PostProcessProfile a, PostProcessProfile b)
    {
        m_fromPostProcessProfile = a;
        m_toPostProcessProfile = b;
        m_tempPostProcessProfile = UnityEngine.ScriptableObject.CreateInstance<PostProcessProfile>();
        m_tempPostProcessProfile.name = TEMP_NAME;

        m_ambientOcclusionTransition = new AmbientOcclusionLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_autoExposureTransition = new AutoExposureLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_bloomTransition = new BloomLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_chromaticAberrationTransition = new ChromaticAberrationLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_colorGradingTransition = new ColorGradingLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_depthOfFieldTransition = new DepthOfFieldLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_grainTransition = new GrainLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_lensDisstortionTransition = new LensDistortionLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_motionBlurTransition = new MotionBlurLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_screenSpaceReflectionsTransition = new ScreenSpaceReflectionsLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
        m_vignetteTransition = new VignetteLerp(m_fromPostProcessProfile, m_toPostProcessProfile, m_tempPostProcessProfile);
    }

    ~PostProcessProfileLerp()
    {
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
