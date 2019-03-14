using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ScreenSpaceReflectionsTransition : BaseTransition<ScreenSpaceReflections>
{
    public ScreenSpaceReflectionPreset defaultPresent;
    public Vector2 maximumIterationCount;
    public ScreenSpaceReflectionResolution defaultResolution;
    public Vector2 thickness;
    public Vector2 maximumMarchDistance;
    public Vector2 distanceFade;
    public Vector2 vignette;

    public ScreenSpaceReflectionsTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        defaultPresent = m_tempSettings.preset.value;

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

        defaultResolution = m_tempSettings.resolution.value;

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

    public override void Lerp(float value)
    {
        if (!IsValid())
        {
            return;
        }

        //preset
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.preset.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.preset.overrideState))
        {
            m_tempSettings.preset.overrideState = true;

            if (value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.preset.value = m_fromSettings.preset.value;
                }
                else
                {
                    m_tempSettings.preset.value = defaultPresent;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.preset.value = m_toSettings.preset.value;
                }
                else
                {
                    m_tempSettings.preset.value = defaultPresent;
                }
            }
        }
        else
        {
            m_tempSettings.preset.overrideState = false;
        }

        m_tempSettings.maximumIterationCount.value = (int)Mathf.Lerp(maximumIterationCount.x, maximumIterationCount.y, value);

        //resolution
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.resolution.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.resolution.overrideState))
        {
            m_tempSettings.resolution.overrideState = true;

            if (value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.resolution.value = m_fromSettings.resolution.value;
                }
                else
                {
                    m_tempSettings.resolution.value = defaultResolution;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.resolution.value = m_toSettings.resolution.value;
                }
                else
                {
                    m_tempSettings.resolution.value = defaultResolution;
                }
            }
        }
        else
        {
            m_tempSettings.resolution.overrideState = false;
        }

        m_tempSettings.thickness.value = Mathf.Lerp(thickness.x, thickness.y, value);
        m_tempSettings.maximumMarchDistance.value = Mathf.Lerp(maximumMarchDistance.x, maximumMarchDistance.y, value);
        m_tempSettings.distanceFade.value = Mathf.Lerp(distanceFade.x, distanceFade.y, value);
        m_tempSettings.vignette.value = Mathf.Lerp(vignette.x, vignette.y, value);
    }
}
