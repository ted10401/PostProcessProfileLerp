using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AmbientOcclusionTransition : BaseTransition<AmbientOcclusion>
{
    private Vector2 m_intensity;
    private Color m_fromColor;
    private Color m_toColor;
    private Vector2 m_noiseFilterTolerance;
    private Vector2 m_blurTolerance;
    private Vector2 m_upsampleTolerance;
    private Vector2 m_thicknessModifier;
    private Vector2 m_directLightingStrength;
    private Vector2 m_radius;

    public AmbientOcclusionTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //mode
        if ((m_fromSettings != null && m_fromSettings.mode.overrideState) ||
            (m_toSettings != null && m_toSettings.mode.overrideState))
        {
            m_tempSettings.mode.overrideState = true;

            if (m_toSettings != null)
            {
                m_tempSettings.mode.value = m_toSettings.mode.value;
            }
            else if (m_fromSettings != null)
            {
                m_tempSettings.mode.value = m_fromSettings.mode.value;
            }
        }
        else
        {
            m_tempSettings.mode.overrideState = false;
        }

        //intensity
        if ((m_fromSettings != null && m_fromSettings.intensity.overrideState) ||
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

        //color
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

        //ambientOnly
        if ((m_fromSettings != null && m_fromSettings.ambientOnly.overrideState) ||
            (m_toSettings != null && m_toSettings.ambientOnly.overrideState))
        {
            m_tempSettings.ambientOnly.overrideState = true;

            if (m_toSettings != null)
            {
                m_tempSettings.ambientOnly.value = m_toSettings.ambientOnly.value;
            }
            else if (m_fromSettings != null)
            {
                m_tempSettings.ambientOnly.value = m_fromSettings.ambientOnly.value;
            }
        }
        else
        {
            m_tempSettings.ambientOnly.overrideState = false;
        }

        //noiseFilterTolerance
        if ((m_fromSettings != null && m_fromSettings.noiseFilterTolerance.overrideState) ||
            (m_toSettings != null && m_toSettings.noiseFilterTolerance.overrideState))
        {
            m_tempSettings.noiseFilterTolerance.overrideState = true;
        }
        else
        {
            m_tempSettings.noiseFilterTolerance.overrideState = false;
        }
        m_noiseFilterTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.noiseFilterTolerance.value;
        m_noiseFilterTolerance.y = m_toSettings == null ? 0f : m_toSettings.noiseFilterTolerance.value;

        //blurTolerance
        if ((m_fromSettings != null && m_fromSettings.blurTolerance.overrideState) ||
            (m_toSettings != null && m_toSettings.blurTolerance.overrideState))
        {
            m_tempSettings.blurTolerance.overrideState = true;
        }
        else
        {
            m_tempSettings.blurTolerance.overrideState = false;
        }
        m_blurTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.blurTolerance.value;
        m_blurTolerance.y = m_toSettings == null ? 0f : m_toSettings.blurTolerance.value;

        //upsampleTolerance
        if ((m_fromSettings != null && m_fromSettings.upsampleTolerance.overrideState) ||
            (m_toSettings != null && m_toSettings.upsampleTolerance.overrideState))
        {
            m_tempSettings.upsampleTolerance.overrideState = true;
        }
        else
        {
            m_tempSettings.upsampleTolerance.overrideState = false;
        }
        m_upsampleTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.upsampleTolerance.value;
        m_upsampleTolerance.y = m_toSettings == null ? 0f : m_toSettings.upsampleTolerance.value;

        //thicknessModifier
        if ((m_fromSettings != null && m_fromSettings.thicknessModifier.overrideState) ||
            (m_toSettings != null && m_toSettings.thicknessModifier.overrideState))
        {
            m_tempSettings.thicknessModifier.overrideState = true;
        }
        else
        {
            m_tempSettings.thicknessModifier.overrideState = false;
        }
        m_thicknessModifier.x = m_fromSettings == null ? 0f : m_fromSettings.thicknessModifier.value;
        m_thicknessModifier.y = m_toSettings == null ? 0f : m_toSettings.thicknessModifier.value;

        //directLightingStrength
        if ((m_fromSettings != null && m_fromSettings.directLightingStrength.overrideState) ||
            (m_toSettings != null && m_toSettings.directLightingStrength.overrideState))
        {
            m_tempSettings.directLightingStrength.overrideState = true;
        }
        else
        {
            m_tempSettings.directLightingStrength.overrideState = false;
        }
        m_directLightingStrength.x = m_fromSettings == null ? 0f : m_fromSettings.directLightingStrength.value;
        m_directLightingStrength.y = m_toSettings == null ? 0f : m_toSettings.directLightingStrength.value;

        //radius
        if ((m_fromSettings != null && m_fromSettings.radius.overrideState) ||
            (m_toSettings != null && m_toSettings.radius.overrideState))
        {
            m_tempSettings.radius.overrideState = true;
        }
        else
        {
            m_tempSettings.radius.overrideState = false;
        }
        m_radius.x = m_fromSettings == null ? 0f : m_fromSettings.radius.value;
        m_radius.y = m_toSettings == null ? 0f : m_toSettings.radius.value;

        //quality
        if ((m_fromSettings != null && m_fromSettings.quality.overrideState) ||
            (m_toSettings != null && m_toSettings.quality.overrideState))
        {
            m_tempSettings.quality.overrideState = true;

            if (m_toSettings != null)
            {
                m_tempSettings.quality.value = m_toSettings.quality.value;
            }
            else if (m_fromSettings != null)
            {
                m_tempSettings.quality.value = m_fromSettings.quality.value;
            }
        }
        else
        {
            m_tempSettings.quality.overrideState = false;
        }
    }

    public override void Transition(float value)
    {
        m_tempSettings.intensity.value = Mathf.Lerp(m_intensity.x, m_intensity.y, value);
        m_tempSettings.color.value = Color.Lerp(m_fromColor, m_toColor, value);
        m_tempSettings.noiseFilterTolerance.value = Mathf.Lerp(m_noiseFilterTolerance.x, m_noiseFilterTolerance.y, value);
        m_tempSettings.blurTolerance.value = Mathf.Lerp(m_blurTolerance.x, m_blurTolerance.y, value);
        m_tempSettings.upsampleTolerance.value = Mathf.Lerp(m_upsampleTolerance.x, m_upsampleTolerance.y, value);
        m_tempSettings.thicknessModifier.value = Mathf.Lerp(m_thicknessModifier.x, m_thicknessModifier.y, value);
        m_tempSettings.directLightingStrength.value = Mathf.Lerp(m_directLightingStrength.x, m_directLightingStrength.y, value);
        m_tempSettings.radius.value = Mathf.Lerp(m_radius.x, m_radius.y, value);
    }
}
