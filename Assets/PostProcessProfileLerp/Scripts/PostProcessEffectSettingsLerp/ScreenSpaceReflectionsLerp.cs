
namespace UnityEngine.Rendering.PostProcessing
{
    public class ScreenSpaceReflectionsLerp : PostProcessEffectSettingsLerp<ScreenSpaceReflections>
    {
        public ScreenSpaceReflectionPreset fromPresent;
        public ScreenSpaceReflectionPreset toPresent;
        public Vector2Int maximumIterationCount;
        public ScreenSpaceReflectionResolution fromResolution;
        public ScreenSpaceReflectionResolution toResolution;
        public Vector2 thickness;
        public Vector2 maximumMarchDistance;
        public Vector2 distanceFade;
        public Vector2 vignette;

        public ScreenSpaceReflectionsLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
        {
        }

        public override void InitializeParameters()
        {
            //preset
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.preset.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.preset.overrideState))
            {
                m_tempSettings.preset.overrideState = true;
            }
            else
            {
                m_tempSettings.preset.overrideState = false;
            }
            fromPresent = m_fromSettings != null && m_fromSettings.active && m_fromSettings.preset.overrideState ? m_fromSettings.preset.value : m_tempSettings.preset.value;
            toPresent = m_toSettings != null && m_toSettings.active && m_toSettings.preset.overrideState ? m_toSettings.preset.value : m_tempSettings.preset.value;

            //maximumIterationCount
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.maximumIterationCount.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.maximumIterationCount.overrideState))
            {
                m_tempSettings.maximumIterationCount.overrideState = true;
            }
            else
            {
                m_tempSettings.maximumIterationCount.overrideState = false;
            }
            maximumIterationCount.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.maximumIterationCount.overrideState ? m_fromSettings.maximumIterationCount.value : m_tempSettings.maximumIterationCount.value;
            maximumIterationCount.y = m_toSettings != null && m_toSettings.active && m_toSettings.maximumIterationCount.overrideState ? m_toSettings.maximumIterationCount.value : m_tempSettings.maximumIterationCount.value;

            //resolution
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.resolution.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.resolution.overrideState))
            {
                m_tempSettings.resolution.overrideState = true;
            }
            else
            {
                m_tempSettings.resolution.overrideState = false;
            }
            fromResolution = m_fromSettings != null && m_fromSettings.active && m_fromSettings.resolution.overrideState ? m_fromSettings.resolution.value : m_tempSettings.resolution.value;
            toResolution = m_toSettings != null && m_toSettings.active && m_toSettings.resolution.overrideState ? m_toSettings.resolution.value : m_tempSettings.resolution.value;

            //thickness
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.thickness.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.thickness.overrideState))
            {
                m_tempSettings.thickness.overrideState = true;
            }
            else
            {
                m_tempSettings.thickness.overrideState = false;
            }
            thickness.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.thickness.overrideState ? m_fromSettings.thickness.value : m_tempSettings.thickness.value;
            thickness.y = m_toSettings != null && m_toSettings.active && m_toSettings.thickness.overrideState ? m_toSettings.thickness.value : m_tempSettings.thickness.value;

            //maximumMarchDistance
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.maximumMarchDistance.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.maximumMarchDistance.overrideState))
            {
                m_tempSettings.maximumMarchDistance.overrideState = true;
            }
            else
            {
                m_tempSettings.maximumMarchDistance.overrideState = false;
            }
            maximumMarchDistance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.maximumMarchDistance.overrideState ? m_fromSettings.maximumMarchDistance.value : m_tempSettings.maximumMarchDistance.value;
            maximumMarchDistance.y = m_toSettings != null && m_toSettings.active && m_toSettings.maximumMarchDistance.overrideState ? m_toSettings.maximumMarchDistance.value : m_tempSettings.maximumMarchDistance.value;

            //distanceFade
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.distanceFade.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.distanceFade.overrideState))
            {
                m_tempSettings.distanceFade.overrideState = true;
            }
            else
            {
                m_tempSettings.distanceFade.overrideState = false;
            }
            distanceFade.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.distanceFade.overrideState ? m_fromSettings.distanceFade.value : m_tempSettings.distanceFade.value;
            distanceFade.y = m_toSettings != null && m_toSettings.active && m_toSettings.distanceFade.overrideState ? m_toSettings.distanceFade.value : m_tempSettings.distanceFade.value;

            //vignette
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.vignette.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.vignette.overrideState))
            {
                m_tempSettings.vignette.overrideState = true;
            }
            else
            {
                m_tempSettings.vignette.overrideState = false;
            }
            vignette.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.vignette.overrideState ? m_fromSettings.vignette.value : m_tempSettings.vignette.value;
            vignette.y = m_toSettings != null && m_toSettings.active && m_toSettings.vignette.overrideState ? m_toSettings.vignette.value : m_tempSettings.vignette.value;
        }

        public override void Lerp(float t)
        {
            if (!IsValid())
            {
                return;
            }

            m_tempSettings.preset.Interp(fromPresent, toPresent, t);
            m_tempSettings.maximumIterationCount.Interp(maximumIterationCount.x, maximumIterationCount.y, t);
            m_tempSettings.resolution.Interp(fromResolution, toResolution, t);
            m_tempSettings.thickness.Interp(thickness.x, thickness.y, t);
            m_tempSettings.maximumMarchDistance.Interp(maximumMarchDistance.x, maximumMarchDistance.y, t);
            m_tempSettings.distanceFade.Interp(distanceFade.x, distanceFade.y, t);
            m_tempSettings.vignette.Interp(vignette.x, vignette.y, t);
        }
    }
}