
namespace UnityEngine.Rendering.PostProcessing
{
    public class AmbientOcclusionLerp : PostProcessEffectSettingsLerp<AmbientOcclusion>
    {
        public AmbientOcclusionMode fromMode;
        public AmbientOcclusionMode toMode;
        public Vector2 intensity;
        public Color fromColor;
        public Color toColor;
        public bool fromAmbientOnly;
        public bool toAmbientOnly;
        public Vector2 noiseFilterTolerance;
        public Vector2 blurTolerance;
        public Vector2 upsampleTolerance;
        public Vector2 thicknessModifier;
        public Vector2 directLightingStrength;
        public Vector2 radius;
        public AmbientOcclusionQuality fromQuality;
        public AmbientOcclusionQuality toQuality;

        public AmbientOcclusionLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
        {
        }

        public override void InitializeParameters()
        {
            //mode
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mode.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.mode.overrideState))
            {
                m_tempSettings.mode.overrideState = true;
            }
            else
            {
                m_tempSettings.mode.overrideState = false;
            }
            fromMode = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mode.overrideState ? m_fromSettings.mode.value : m_tempSettings.mode.value;
            toMode = m_toSettings != null && m_toSettings.active && m_toSettings.mode.overrideState ? m_toSettings.mode.value : m_tempSettings.mode.value;

            //intensity
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensity.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.intensity.overrideState))
            {
                m_tempSettings.intensity.overrideState = true;
            }
            else
            {
                m_tempSettings.intensity.overrideState = false;
            }
            intensity.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensity.overrideState ? m_fromSettings.intensity.value : m_tempSettings.intensity.value;
            intensity.y = m_toSettings != null && m_toSettings.active && m_toSettings.intensity.overrideState ? m_toSettings.intensity.value : m_tempSettings.intensity.value;

            //color
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.color.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.color.overrideState))
            {
                m_tempSettings.color.overrideState = true;
            }
            else
            {
                m_tempSettings.color.overrideState = false;
            }
            fromColor = m_fromSettings != null && m_fromSettings.active && m_fromSettings.color.overrideState ? m_fromSettings.color.value : m_tempSettings.color.value;
            toColor = m_toSettings != null && m_toSettings.active && m_toSettings.color.overrideState ? m_toSettings.color.value : m_tempSettings.color.value;

            //ambientOnly
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.ambientOnly.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.ambientOnly.overrideState))
            {
                m_tempSettings.ambientOnly.overrideState = true;
            }
            else
            {
                m_tempSettings.ambientOnly.overrideState = false;
            }
            fromAmbientOnly = m_fromSettings != null && m_fromSettings.active && m_fromSettings.ambientOnly.overrideState ? m_fromSettings.ambientOnly.value : m_tempSettings.ambientOnly.value;
            toAmbientOnly = m_toSettings != null && m_toSettings.active && m_toSettings.ambientOnly.overrideState ? m_toSettings.ambientOnly.value : m_tempSettings.ambientOnly.value;

            //noiseFilterTolerance
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.noiseFilterTolerance.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.noiseFilterTolerance.overrideState))
            {
                m_tempSettings.noiseFilterTolerance.overrideState = true;
            }
            else
            {
                m_tempSettings.noiseFilterTolerance.overrideState = false;
            }
            noiseFilterTolerance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.noiseFilterTolerance.overrideState ? m_fromSettings.noiseFilterTolerance.value : m_tempSettings.noiseFilterTolerance.value;
            noiseFilterTolerance.y = m_toSettings != null && m_toSettings.active && m_toSettings.noiseFilterTolerance.overrideState ? m_toSettings.noiseFilterTolerance.value : m_tempSettings.noiseFilterTolerance.value;

            //blurTolerance
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.blurTolerance.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.blurTolerance.overrideState))
            {
                m_tempSettings.blurTolerance.overrideState = true;
            }
            else
            {
                m_tempSettings.blurTolerance.overrideState = false;
            }
            blurTolerance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.blurTolerance.overrideState ? m_fromSettings.blurTolerance.value : m_tempSettings.blurTolerance.value;
            blurTolerance.y = m_toSettings != null && m_toSettings.active && m_toSettings.blurTolerance.overrideState ? m_toSettings.blurTolerance.value : m_tempSettings.blurTolerance.value;

            //upsampleTolerance
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.upsampleTolerance.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.upsampleTolerance.overrideState))
            {
                m_tempSettings.upsampleTolerance.overrideState = true;
            }
            else
            {
                m_tempSettings.upsampleTolerance.overrideState = false;
            }
            upsampleTolerance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.upsampleTolerance.overrideState ? m_fromSettings.upsampleTolerance.value : m_tempSettings.upsampleTolerance.value;
            upsampleTolerance.y = m_toSettings != null && m_toSettings.active && m_toSettings.upsampleTolerance.overrideState ? m_toSettings.upsampleTolerance.value : m_tempSettings.upsampleTolerance.value;

            //thicknessModifier
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.thicknessModifier.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.thicknessModifier.overrideState))
            {
                m_tempSettings.thicknessModifier.overrideState = true;
            }
            else
            {
                m_tempSettings.thicknessModifier.overrideState = false;
            }
            thicknessModifier.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.thicknessModifier.overrideState ? m_fromSettings.thicknessModifier.value : m_tempSettings.thicknessModifier.value;
            thicknessModifier.y = m_toSettings != null && m_toSettings.active && m_toSettings.thicknessModifier.overrideState ? m_toSettings.thicknessModifier.value : m_tempSettings.thicknessModifier.value;

            //directLightingStrength
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.directLightingStrength.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.directLightingStrength.overrideState))
            {
                m_tempSettings.directLightingStrength.overrideState = true;
            }
            else
            {
                m_tempSettings.directLightingStrength.overrideState = false;
            }
            directLightingStrength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.directLightingStrength.overrideState ? m_fromSettings.directLightingStrength.value : m_tempSettings.directLightingStrength.value;
            directLightingStrength.y = m_toSettings != null && m_toSettings.active && m_toSettings.directLightingStrength.overrideState ? m_toSettings.directLightingStrength.value : m_tempSettings.directLightingStrength.value;

            //radius
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.radius.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.radius.overrideState))
            {
                m_tempSettings.radius.overrideState = true;
            }
            else
            {
                m_tempSettings.radius.overrideState = false;
            }
            radius.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.radius.overrideState ? m_fromSettings.radius.value : m_tempSettings.radius.value;
            radius.y = m_toSettings != null && m_toSettings.active && m_toSettings.radius.overrideState ? m_toSettings.radius.value : m_tempSettings.radius.value;

            //quality
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.quality.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.quality.overrideState))
            {
                m_tempSettings.quality.overrideState = true;
            }
            else
            {
                m_tempSettings.quality.overrideState = false;
            }
            fromQuality = m_fromSettings != null && m_fromSettings.active && m_fromSettings.quality.overrideState ? m_fromSettings.quality.value : m_tempSettings.quality.value;
            toQuality = m_toSettings != null && m_toSettings.active && m_toSettings.quality.overrideState ? m_toSettings.quality.value : m_tempSettings.quality.value;
        }

        public override void Lerp(float t)
        {
            if (!IsValid())
            {
                return;
            }

            m_tempSettings.mode.Interp(fromMode, toMode, t);
            m_tempSettings.intensity.Interp(intensity.x, intensity.y, t);
            m_tempSettings.color.Interp(fromColor, toColor, t);
            m_tempSettings.ambientOnly.Interp(fromAmbientOnly, toAmbientOnly, t);
            m_tempSettings.noiseFilterTolerance.Interp(noiseFilterTolerance.x, noiseFilterTolerance.y, t);
            m_tempSettings.blurTolerance.Interp(blurTolerance.x, blurTolerance.y, t);
            m_tempSettings.upsampleTolerance.Interp(upsampleTolerance.x, upsampleTolerance.y, t);
            m_tempSettings.thicknessModifier.Interp(thicknessModifier.x, thicknessModifier.y, t);
            m_tempSettings.directLightingStrength.Interp(directLightingStrength.x, directLightingStrength.y, t);
            m_tempSettings.radius.Interp(radius.x, radius.y, t);
            m_tempSettings.quality.Interp(fromQuality, toQuality, t);
        }
    }
}