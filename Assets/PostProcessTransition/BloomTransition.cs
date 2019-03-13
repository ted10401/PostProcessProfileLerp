using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class BloomTransition : BaseTransition<Bloom>
{
    private Vector2 m_intensity;
    private Vector2 m_threshold;
    private Vector2 m_softKnee;
    private Vector2 m_clamp;
    private Vector2 m_diffusion;
    private Vector2 m_anamorphicRatio;
    private Color m_fromColor;
    private Color m_toColor;
    private Vector2 m_dirtIntensity;

    public BloomTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        if((m_fromSettings != null && m_fromSettings.intensity.overrideState) ||
            (m_toSettings != null && m_toSettings.intensity.overrideState))
        {
            m_tempSettings.intensity.overrideState = true;
        }
        else
        {
            m_tempSettings.intensity.overrideState = false;
        }
        m_intensity.x = m_fromSettings == null ? 0f : m_fromSettings.intensity.value;
        m_intensity.y = m_toSettings == null ? 0f : m_toSettings.intensity.value;

        if ((m_fromSettings != null && m_fromSettings.threshold.overrideState) ||
            (m_toSettings != null && m_toSettings.threshold.overrideState))
        {
            m_tempSettings.threshold.overrideState = true;
        }
        else
        {
            m_tempSettings.threshold.overrideState = false;
        }
        m_threshold.x = m_fromSettings == null ? 0f : m_fromSettings.threshold.value;
        m_threshold.y = m_toSettings == null ? 0f : m_toSettings.threshold.value;

        if ((m_fromSettings != null && m_fromSettings.softKnee.overrideState) ||
            (m_toSettings != null && m_toSettings.softKnee.overrideState))
        {
            m_tempSettings.softKnee.overrideState = true;
        }
        else
        {
            m_tempSettings.softKnee.overrideState = false;
        }
        m_softKnee.x = m_fromSettings == null ? 0f : m_fromSettings.softKnee.value;
        m_softKnee.y = m_toSettings == null ? 0f : m_toSettings.softKnee.value;

        if ((m_fromSettings != null && m_fromSettings.clamp.overrideState) ||
            (m_toSettings != null && m_toSettings.clamp.overrideState))
        {
            m_tempSettings.clamp.overrideState = true;
        }
        else
        {
            m_tempSettings.clamp.overrideState = false;
        }
        m_clamp.x = m_fromSettings == null ? 0f : m_fromSettings.clamp.value;
        m_clamp.y = m_toSettings == null ? 0f : m_toSettings.clamp.value;

        if ((m_fromSettings != null && m_fromSettings.diffusion.overrideState) ||
            (m_toSettings != null && m_toSettings.diffusion.overrideState))
        {
            m_tempSettings.diffusion.overrideState = true;
        }
        else
        {
            m_tempSettings.diffusion.overrideState = false;
        }
        m_diffusion.x = m_fromSettings == null ? 0f : m_fromSettings.diffusion.value;
        m_diffusion.y = m_toSettings == null ? 0f : m_toSettings.diffusion.value;

        if ((m_fromSettings != null && m_fromSettings.anamorphicRatio.overrideState) ||
            (m_toSettings != null && m_toSettings.anamorphicRatio.overrideState))
        {
            m_tempSettings.anamorphicRatio.overrideState = true;
        }
        else
        {
            m_tempSettings.anamorphicRatio.overrideState = false;
        }
        m_anamorphicRatio.x = m_fromSettings == null ? 0f : m_fromSettings.anamorphicRatio.value;
        m_anamorphicRatio.y = m_toSettings == null ? 0f : m_toSettings.anamorphicRatio.value;

        if ((m_fromSettings != null && m_fromSettings.color.overrideState) ||
            (m_toSettings != null && m_toSettings.color.overrideState))
        {
            m_tempSettings.color.overrideState = true;
        }
        else
        {
            m_tempSettings.color.overrideState = false;
        }
        m_fromColor = m_fromSettings == null ? Color.white : m_fromSettings.color.value;
        m_toColor = m_toSettings == null ? Color.white : m_toSettings.color.value;

        if ((m_fromSettings != null && m_fromSettings.dirtIntensity.overrideState) ||
            (m_toSettings != null && m_toSettings.dirtIntensity.overrideState))
        {
            m_tempSettings.dirtIntensity.overrideState = true;
        }
        else
        {
            m_tempSettings.dirtIntensity.overrideState = false;
        }
        m_dirtIntensity.x = m_fromSettings == null ? 0f : m_fromSettings.dirtIntensity.value;
        m_dirtIntensity.y = m_toSettings == null ? 0f : m_toSettings.dirtIntensity.value;

        if ((m_fromSettings != null && m_fromSettings.fastMode.overrideState) ||
            (m_toSettings != null && m_toSettings.fastMode.overrideState))
        {
            m_tempSettings.fastMode.overrideState = true;

            if(m_toSettings != null)
            {
                m_tempSettings.fastMode.value = m_toSettings.fastMode.value;
            }
            else if(m_fromSettings != null)
            {
                m_tempSettings.fastMode.value = m_fromSettings.fastMode.value;
            }
        }
        else
        {
            m_tempSettings.fastMode.overrideState = false;
        }
    }

    public override void Transition(float value)
    {
        m_tempSettings.intensity.value = Mathf.Lerp(m_intensity.x, m_intensity.y, value);
        m_tempSettings.threshold.value = Mathf.Lerp(m_threshold.x, m_threshold.y, value);
        m_tempSettings.softKnee.value = Mathf.Lerp(m_softKnee.x, m_softKnee.y, value);
        m_tempSettings.clamp.value = Mathf.Lerp(m_clamp.x, m_clamp.y, value);
        m_tempSettings.diffusion.value = Mathf.Lerp(m_diffusion.x, m_diffusion.y, value);
        m_tempSettings.anamorphicRatio.value = Mathf.Lerp(m_anamorphicRatio.x, m_anamorphicRatio.y, value);
        m_tempSettings.color.value = Color.Lerp(m_fromColor, m_toColor, value);
        m_tempSettings.dirtIntensity.value = Mathf.Lerp(m_dirtIntensity.x, m_dirtIntensity.y, value);
    }
}
