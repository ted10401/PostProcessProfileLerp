﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ScreenSpaceReflectionsTransition : BaseTransition<ScreenSpaceReflections>
{
    public Vector2 maximumIterationCount;
    public Vector2 thickness;
    public Vector2 maximumMarchDistance;
    public Vector2 distanceFade;
    public Vector2 vignette;

    public ScreenSpaceReflectionsTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //maximumIterationCount
        if ((m_fromSettings != null && m_fromSettings.maximumIterationCount.overrideState) ||
            (m_toSettings != null && m_toSettings.maximumIterationCount.overrideState))
        {
            m_tempSettings.maximumIterationCount.overrideState = true;
        }
        else
        {
            m_tempSettings.maximumIterationCount.overrideState = false;
        }
        maximumIterationCount.x = m_fromSettings == null ? 0f : m_fromSettings.maximumIterationCount.value;
        maximumIterationCount.y = m_toSettings == null ? 0f : m_toSettings.maximumIterationCount.value;

        //thickness
        if ((m_fromSettings != null && m_fromSettings.thickness.overrideState) ||
            (m_toSettings != null && m_toSettings.thickness.overrideState))
        {
            m_tempSettings.thickness.overrideState = true;
        }
        else
        {
            m_tempSettings.thickness.overrideState = false;
        }
        thickness.x = m_fromSettings == null ? 0f : m_fromSettings.thickness.value;
        thickness.y = m_toSettings == null ? 0f : m_toSettings.thickness.value;

        //maximumMarchDistance
        if ((m_fromSettings != null && m_fromSettings.maximumMarchDistance.overrideState) ||
            (m_toSettings != null && m_toSettings.maximumMarchDistance.overrideState))
        {
            m_tempSettings.maximumMarchDistance.overrideState = true;
        }
        else
        {
            m_tempSettings.maximumMarchDistance.overrideState = false;
        }
        maximumMarchDistance.x = m_fromSettings == null ? 0f : m_fromSettings.maximumMarchDistance.value;
        maximumMarchDistance.y = m_toSettings == null ? 0f : m_toSettings.maximumMarchDistance.value;

        //distanceFade
        if ((m_fromSettings != null && m_fromSettings.distanceFade.overrideState) ||
            (m_toSettings != null && m_toSettings.distanceFade.overrideState))
        {
            m_tempSettings.distanceFade.overrideState = true;
        }
        else
        {
            m_tempSettings.distanceFade.overrideState = false;
        }
        distanceFade.x = m_fromSettings == null ? 0f : m_fromSettings.distanceFade.value;
        distanceFade.y = m_toSettings == null ? 0f : m_toSettings.distanceFade.value;

        //vignette
        if ((m_fromSettings != null && m_fromSettings.vignette.overrideState) ||
            (m_toSettings != null && m_toSettings.vignette.overrideState))
        {
            m_tempSettings.vignette.overrideState = true;
        }
        else
        {
            m_tempSettings.vignette.overrideState = false;
        }
        vignette.x = m_fromSettings == null ? 0f : m_fromSettings.vignette.value;
        vignette.y = m_toSettings == null ? 0f : m_toSettings.vignette.value;
    }

    public override void Lerp(float value)
    {
        if (!IsValid())
        {
            return;
        }

        //preset
        if ((m_fromSettings != null && m_fromSettings.preset.overrideState) ||
            (m_toSettings != null && m_toSettings.preset.overrideState))
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
                    //m_tempSettings.preset.value = false;
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
                    //m_tempSettings.preset.value = false;
                }
            }
        }
        else
        {
            m_tempSettings.preset.overrideState = false;
        }

        m_tempSettings.maximumIterationCount.value = (int)Mathf.Lerp(maximumIterationCount.x, maximumIterationCount.y, value);

        //resolution
        if ((m_fromSettings != null && m_fromSettings.resolution.overrideState) ||
            (m_toSettings != null && m_toSettings.resolution.overrideState))
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
                    //m_tempSettings.resolution.value = false;
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
                    //m_tempSettings.resolution.value = false;
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
