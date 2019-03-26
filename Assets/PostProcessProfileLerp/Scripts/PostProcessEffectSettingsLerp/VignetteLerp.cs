
namespace UnityEngine.Rendering.PostProcessing
{
    public class VignetteLerp : PostProcessEffectSettingsLerp<Vignette>
    {
        public VignetteMode fromMode;
        public VignetteMode toMode;
        public Color fromColor;
        public Color toColor;
        public Vector2 fromCenter;
        public Vector2 toCenter;
        public Vector2 intensity;
        public Vector2 smoothness;
        public Vector2 roundness;
        public bool fromRounded;
        public bool toRounded;
        public Texture fromMask;
        public Texture toMask;
        public Vector2 opacity;

        public VignetteLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
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

            //center
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.center.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.center.overrideState))
            {
                m_tempSettings.center.overrideState = true;
            }
            else
            {
                m_tempSettings.center.overrideState = false;
            }
            fromCenter = m_fromSettings != null && m_fromSettings.active && m_fromSettings.center.overrideState ? m_fromSettings.center.value : m_tempSettings.center.value;
            toCenter = m_toSettings != null && m_toSettings.active && m_toSettings.center.overrideState ? m_toSettings.center.value : m_tempSettings.center.value;

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

            //smoothness
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.smoothness.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.smoothness.overrideState))
            {
                m_tempSettings.smoothness.overrideState = true;
            }
            else
            {
                m_tempSettings.smoothness.overrideState = false;
            }
            smoothness.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.smoothness.overrideState ? m_fromSettings.smoothness.value : m_tempSettings.smoothness.value;
            smoothness.y = m_toSettings != null && m_toSettings.active && m_toSettings.smoothness.overrideState ? m_toSettings.smoothness.value : m_tempSettings.smoothness.value;

            //roundness
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.roundness.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.roundness.overrideState))
            {
                m_tempSettings.roundness.overrideState = true;
            }
            else
            {
                m_tempSettings.roundness.overrideState = false;
            }
            roundness.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.roundness.overrideState ? m_fromSettings.roundness.value : m_tempSettings.roundness.value;
            roundness.y = m_toSettings != null && m_toSettings.active && m_toSettings.roundness.overrideState ? m_toSettings.roundness.value : m_tempSettings.roundness.value;

            //rounded
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.rounded.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.rounded.overrideState))
            {
                m_tempSettings.rounded.overrideState = true;
            }
            else
            {
                m_tempSettings.rounded.overrideState = false;
            }
            fromRounded = m_fromSettings != null && m_fromSettings.active && m_fromSettings.rounded.overrideState ? m_fromSettings.rounded.value : m_tempSettings.rounded.value;
            toRounded = m_toSettings != null && m_toSettings.active && m_toSettings.rounded.overrideState ? m_toSettings.rounded.value : m_tempSettings.rounded.value;

            //mask
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mask.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.mask.overrideState))
            {
                m_tempSettings.mask.overrideState = true;
            }
            else
            {
                m_tempSettings.mask.overrideState = false;
            }
            fromMask = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mask.overrideState ? m_fromSettings.mask.value : m_tempSettings.mask.value;
            toMask = m_toSettings != null && m_toSettings.active && m_toSettings.mask.overrideState ? m_toSettings.mask.value : m_tempSettings.mask.value;

            //opacity
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.opacity.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.opacity.overrideState))
            {
                m_tempSettings.opacity.overrideState = true;
            }
            else
            {
                m_tempSettings.opacity.overrideState = false;
            }
            opacity.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.opacity.overrideState ? m_fromSettings.opacity.value : m_tempSettings.opacity.value;
            opacity.y = m_toSettings != null && m_toSettings.active && m_toSettings.opacity.overrideState ? m_toSettings.opacity.value : m_tempSettings.opacity.value;
        }

        public override void Lerp(float t)
        {
            if (!IsValid())
            {
                return;
            }

            m_tempSettings.mode.Interp(fromMode, toMode, t);
            m_tempSettings.color.Interp(fromColor, toColor, t);
            m_tempSettings.center.Interp(fromCenter, toCenter, t);
            m_tempSettings.intensity.Interp(intensity.x, intensity.y, t);
            m_tempSettings.smoothness.Interp(smoothness.x, smoothness.y, t);
            m_tempSettings.roundness.Interp(roundness.x, roundness.y, t);
            m_tempSettings.rounded.Interp(fromRounded, toRounded, t);
            m_tempSettings.mask.Interp(fromMask, toMask, t);
            m_tempSettings.opacity.Interp(opacity.x, opacity.y, t);
        }
    }
}