using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AmbientOcclusionTransition : BaseTransition<AmbientOcclusion>
{
    public Vector2 intensity;
    public Color fromColor;
    public Color toColor;
    public Vector2 noiseFilterTolerance;
    public Vector2 blurTolerance;
    public Vector2 upsampleTolerance;
    public Vector2 thicknessModifier;
    public Vector2 directLightingStrength;
    public Vector2 radius;

    public AmbientOcclusionTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
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
        intensity.x = m_fromSettings == null ? 0f : m_fromSettings.intensity.value;
        intensity.y = m_toSettings == null ? 0f : m_toSettings.intensity.value;

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
        fromColor = m_fromSettings == null ? Color.white : m_fromSettings.color.value;
        toColor = m_toSettings == null ? Color.white : m_toSettings.color.value;

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
        noiseFilterTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.noiseFilterTolerance.value;
        noiseFilterTolerance.y = m_toSettings == null ? 0f : m_toSettings.noiseFilterTolerance.value;

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
        blurTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.blurTolerance.value;
        blurTolerance.y = m_toSettings == null ? 0f : m_toSettings.blurTolerance.value;

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
        upsampleTolerance.x = m_fromSettings == null ? 0f : m_fromSettings.upsampleTolerance.value;
        upsampleTolerance.y = m_toSettings == null ? 0f : m_toSettings.upsampleTolerance.value;

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
        thicknessModifier.x = m_fromSettings == null ? 0f : m_fromSettings.thicknessModifier.value;
        thicknessModifier.y = m_toSettings == null ? 0f : m_toSettings.thicknessModifier.value;

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
        directLightingStrength.x = m_fromSettings == null ? 0f : m_fromSettings.directLightingStrength.value;
        directLightingStrength.y = m_toSettings == null ? 0f : m_toSettings.directLightingStrength.value;

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
        radius.x = m_fromSettings == null ? 0f : m_fromSettings.radius.value;
        radius.y = m_toSettings == null ? 0f : m_toSettings.radius.value;
    }

    public override void Lerp(float value)
    {
        //mode
        if ((m_fromSettings != null && m_fromSettings.mode.overrideState) ||
            (m_toSettings != null && m_toSettings.mode.overrideState))
        {
            m_tempSettings.mode.overrideState = true;

            if(value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.mode.value = m_fromSettings.mode.value;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.mode.value = m_toSettings.mode.value;
                }
            }
        }
        else
        {
            m_tempSettings.mode.overrideState = false;
        }

        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, value);
        m_tempSettings.color.value = Color.Lerp(fromColor, toColor, value);

        //ambientOnly
        if ((m_fromSettings != null && m_fromSettings.ambientOnly.overrideState) ||
            (m_toSettings != null && m_toSettings.ambientOnly.overrideState))
        {
            m_tempSettings.ambientOnly.overrideState = true;

            if(value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.ambientOnly.value = m_fromSettings.ambientOnly.value;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.ambientOnly.value = m_toSettings.ambientOnly.value;
                }
            }
        }
        else
        {
            m_tempSettings.ambientOnly.overrideState = false;
        }

        m_tempSettings.noiseFilterTolerance.value = Mathf.Lerp(noiseFilterTolerance.x, noiseFilterTolerance.y, value);
        m_tempSettings.blurTolerance.value = Mathf.Lerp(blurTolerance.x, blurTolerance.y, value);
        m_tempSettings.upsampleTolerance.value = Mathf.Lerp(upsampleTolerance.x, upsampleTolerance.y, value);
        m_tempSettings.thicknessModifier.value = Mathf.Lerp(thicknessModifier.x, thicknessModifier.y, value);
        m_tempSettings.directLightingStrength.value = Mathf.Lerp(directLightingStrength.x, directLightingStrength.y, value);
        m_tempSettings.radius.value = Mathf.Lerp(radius.x, radius.y, value);

        //quality
        if ((m_fromSettings != null && m_fromSettings.quality.overrideState) ||
            (m_toSettings != null && m_toSettings.quality.overrideState))
        {
            m_tempSettings.quality.overrideState = true;

            if(value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.quality.value = m_fromSettings.quality.value;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.quality.value = m_toSettings.quality.value;
                }
            }
        }
        else
        {
            m_tempSettings.quality.overrideState = false;
        }
    }
}
