using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AmbientOcclusionLerp : PostProcessEffectSettingsLerp<AmbientOcclusion>
{
    public AmbientOcclusionMode defaultMode;
    public Vector2 intensity;
    public Color fromColor;
    public Color toColor;
    public bool defaultAmbientOnly;
    public Vector2 noiseFilterTolerance;
    public Vector2 blurTolerance;
    public Vector2 upsampleTolerance;
    public Vector2 thicknessModifier;
    public Vector2 directLightingStrength;
    public Vector2 radius;
    public AmbientOcclusionQuality defaultQuality;

    public AmbientOcclusionLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        defaultMode = m_tempSettings.mode.value;

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

        defaultAmbientOnly = m_tempSettings.ambientOnly;

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

        defaultQuality = m_tempSettings.quality.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        //mode
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mode.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mode.overrideState))
        {
            m_tempSettings.mode.overrideState = true;

            if(t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.mode.value = m_fromSettings.mode.value;
                }
                else
                {
                    m_tempSettings.mode.value = defaultMode;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.mode.value = m_toSettings.mode.value;
                }
                else
                {
                    m_tempSettings.mode.value = defaultMode;
                }
            }
        }
        else
        {
            m_tempSettings.mode.overrideState = false;
        }

        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, t);
        m_tempSettings.color.value = Color.Lerp(fromColor, toColor, t);

        //ambientOnly
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.ambientOnly.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.ambientOnly.overrideState))
        {
            m_tempSettings.ambientOnly.overrideState = true;

            if(t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.ambientOnly.value = m_fromSettings.ambientOnly.value;
                }
                else
                {
                    m_tempSettings.ambientOnly.value = defaultAmbientOnly;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.ambientOnly.value = m_toSettings.ambientOnly.value;
                }
                else
                {
                    m_tempSettings.ambientOnly.value = defaultAmbientOnly;
                }
            }
        }
        else
        {
            m_tempSettings.ambientOnly.overrideState = false;
        }

        m_tempSettings.noiseFilterTolerance.value = Mathf.Lerp(noiseFilterTolerance.x, noiseFilterTolerance.y, t);
        m_tempSettings.blurTolerance.value = Mathf.Lerp(blurTolerance.x, blurTolerance.y, t);
        m_tempSettings.upsampleTolerance.value = Mathf.Lerp(upsampleTolerance.x, upsampleTolerance.y, t);
        m_tempSettings.thicknessModifier.value = Mathf.Lerp(thicknessModifier.x, thicknessModifier.y, t);
        m_tempSettings.directLightingStrength.value = Mathf.Lerp(directLightingStrength.x, directLightingStrength.y, t);
        m_tempSettings.radius.value = Mathf.Lerp(radius.x, radius.y, t);

        //quality
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.quality.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.quality.overrideState))
        {
            m_tempSettings.quality.overrideState = true;

            if(t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.quality.value = m_fromSettings.quality.value;
                }
                else
                {
                    m_tempSettings.quality.value = defaultQuality;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.quality.value = m_toSettings.quality.value;
                }
                else
                {
                    m_tempSettings.quality.value = defaultQuality;
                }
            }
        }
        else
        {
            m_tempSettings.quality.overrideState = false;
        }
    }
}
