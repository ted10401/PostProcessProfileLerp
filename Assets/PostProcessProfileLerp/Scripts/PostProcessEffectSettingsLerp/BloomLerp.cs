
namespace UnityEngine.Rendering.PostProcessing
{
    public class BloomLerp : PostProcessEffectSettingsLerp<Bloom>
    {
        public Vector2 intensity;
        public Vector2 threshold;
        public Vector2 softKnee;
        public Vector2 clamp;
        public Vector2 diffusion;
        public Vector2 anamorphicRatio;
        public Color fromColor;
        public Color toColor;
        public Vector2 dirtIntensity;
        public bool fromFastMode;
        public bool toFastMode;
        public Texture fromDirtTexture;
        public Texture toDirtTexture;

        public BloomLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
        {
        }

        public override void InitializeParameters()
        {
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

            //threshold
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.threshold.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.threshold.overrideState))
            {
                m_tempSettings.threshold.overrideState = true;
            }
            else
            {
                m_tempSettings.threshold.overrideState = false;
            }
            threshold.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.threshold.overrideState ? m_fromSettings.threshold.value : m_tempSettings.threshold.value;
            threshold.y = m_toSettings != null && m_toSettings.active && m_toSettings.threshold.overrideState ? m_toSettings.threshold.value : m_tempSettings.threshold.value;

            //softKnee
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.softKnee.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.softKnee.overrideState))
            {
                m_tempSettings.softKnee.overrideState = true;
            }
            else
            {
                m_tempSettings.softKnee.overrideState = false;
            }
            softKnee.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.softKnee.overrideState ? m_fromSettings.softKnee.value : m_tempSettings.softKnee.value;
            softKnee.y = m_toSettings != null && m_toSettings.active && m_toSettings.softKnee.overrideState ? m_toSettings.softKnee.value : m_tempSettings.softKnee.value;

            //clamp
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.clamp.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.clamp.overrideState))
            {
                m_tempSettings.clamp.overrideState = true;
            }
            else
            {
                m_tempSettings.clamp.overrideState = false;
            }
            clamp.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.clamp.overrideState ? m_fromSettings.clamp.value : m_tempSettings.clamp.value;
            clamp.y = m_toSettings != null && m_toSettings.active && m_toSettings.clamp.overrideState ? m_toSettings.clamp.value : m_tempSettings.clamp.value;

            //diffusion
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.diffusion.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.diffusion.overrideState))
            {
                m_tempSettings.diffusion.overrideState = true;
            }
            else
            {
                m_tempSettings.diffusion.overrideState = false;
            }
            diffusion.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.diffusion.overrideState ? m_fromSettings.diffusion.value : m_tempSettings.diffusion.value;
            diffusion.y = m_toSettings != null && m_toSettings.active && m_toSettings.diffusion.overrideState ? m_toSettings.diffusion.value : m_tempSettings.diffusion.value;

            //anamorphicRatio
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.anamorphicRatio.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.anamorphicRatio.overrideState))
            {
                m_tempSettings.anamorphicRatio.overrideState = true;
            }
            else
            {
                m_tempSettings.anamorphicRatio.overrideState = false;
            }
            anamorphicRatio.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.anamorphicRatio.overrideState ? m_fromSettings.anamorphicRatio.value : m_tempSettings.anamorphicRatio.value;
            anamorphicRatio.y = m_toSettings != null && m_toSettings.active && m_toSettings.anamorphicRatio.overrideState ? m_toSettings.anamorphicRatio.value : m_tempSettings.anamorphicRatio.value;

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

            //dirtIntensity
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.dirtIntensity.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.dirtIntensity.overrideState))
            {
                m_tempSettings.dirtIntensity.overrideState = true;
            }
            else
            {
                m_tempSettings.dirtIntensity.overrideState = false;
            }
            dirtIntensity.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.dirtIntensity.overrideState ? m_fromSettings.dirtIntensity.value : m_tempSettings.dirtIntensity.value;
            dirtIntensity.y = m_toSettings != null && m_toSettings.active && m_toSettings.dirtIntensity.overrideState ? m_toSettings.dirtIntensity.value : m_tempSettings.dirtIntensity.value;

            //fastMode
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.fastMode.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.fastMode.overrideState))
            {
                m_tempSettings.fastMode.overrideState = true;
            }
            else
            {
                m_tempSettings.fastMode.overrideState = false;
            }
            fromFastMode = m_fromSettings != null && m_fromSettings.active && m_fromSettings.fastMode.overrideState ? m_fromSettings.fastMode.value : m_tempSettings.fastMode.value;
            toFastMode = m_toSettings != null && m_toSettings.active && m_toSettings.fastMode.overrideState ? m_toSettings.fastMode.value : m_tempSettings.fastMode.value;

            //dirtTexture
            if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.dirtTexture.overrideState) ||
                (m_toSettings != null && m_toSettings.active && m_toSettings.dirtTexture.overrideState))
            {
                m_tempSettings.dirtTexture.overrideState = true;
            }
            else
            {
                m_tempSettings.dirtTexture.overrideState = false;
            }
            fromDirtTexture = m_fromSettings != null && m_fromSettings.active && m_fromSettings.dirtTexture.overrideState ? m_fromSettings.dirtTexture.value : m_tempSettings.dirtTexture.value;
            toDirtTexture = m_toSettings != null && m_toSettings.active && m_toSettings.dirtTexture.overrideState ? m_toSettings.dirtTexture.value : m_tempSettings.dirtTexture.value;
        }

        public override void Lerp(float t)
        {
            if (!IsValid())
            {
                return;
            }

            m_tempSettings.intensity.Interp(intensity.x, intensity.y, t);
            m_tempSettings.threshold.Interp(threshold.x, threshold.y, t);
            m_tempSettings.softKnee.Interp(softKnee.x, softKnee.y, t);
            m_tempSettings.clamp.Interp(clamp.x, clamp.y, t);
            m_tempSettings.diffusion.Interp(diffusion.x, diffusion.y, t);
            m_tempSettings.anamorphicRatio.Interp(anamorphicRatio.x, anamorphicRatio.y, t);
            m_tempSettings.color.Interp(fromColor, toColor, t);
            m_tempSettings.dirtIntensity.Interp(dirtIntensity.x, dirtIntensity.y, t);
            m_tempSettings.fastMode.Interp(fromFastMode, toFastMode, t);
            m_tempSettings.dirtTexture.Interp(fromDirtTexture, toDirtTexture, t);
        }
    }
}