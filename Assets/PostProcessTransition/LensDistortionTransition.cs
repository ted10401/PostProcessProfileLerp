using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LensDistortionTransition : BaseTransition<LensDistortion>
{
    public Vector2 intensity;
    public Vector2 intensityX;
    public Vector2 intensityY;
    public Vector2 centerX;
    public Vector2 centerY;
    public Vector2 scale;

    public LensDistortionTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
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

        //intensityX
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensityX.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.intensityX.overrideState))
        {
            m_tempSettings.intensityX.overrideState = true;
        }
        else
        {
            m_tempSettings.intensityX.overrideState = false;
        }
        intensityX.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensityX.overrideState ? m_fromSettings.intensityX.value : m_tempSettings.intensityX.value;
        intensityX.y = m_toSettings != null && m_toSettings.active && m_toSettings.intensityX.overrideState ? m_toSettings.intensityX.value : m_tempSettings.intensityX.value;

        //intensityY
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensityY.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.intensityY.overrideState))
        {
            m_tempSettings.intensityY.overrideState = true;
        }
        else
        {
            m_tempSettings.intensityY.overrideState = false;
        }
        intensityY.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.intensityY.overrideState ? m_fromSettings.intensityY.value : m_tempSettings.intensityY.value;
        intensityY.y = m_toSettings != null && m_toSettings.active && m_toSettings.intensityY.overrideState ? m_toSettings.intensityY.value : m_tempSettings.intensityY.value;

        //centerX
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.centerX.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.centerX.overrideState))
        {
            m_tempSettings.centerX.overrideState = true;
        }
        else
        {
            m_tempSettings.centerX.overrideState = false;
        }
        centerX.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.centerX.overrideState ? m_fromSettings.centerX.value : m_tempSettings.centerX.value;
        centerX.y = m_toSettings != null && m_toSettings.active && m_toSettings.centerX.overrideState ? m_toSettings.centerX.value : m_tempSettings.centerX.value;

        //centerY
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.centerY.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.centerY.overrideState))
        {
            m_tempSettings.centerY.overrideState = true;
        }
        else
        {
            m_tempSettings.centerY.overrideState = false;
        }
        centerY.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.centerY.overrideState ? m_fromSettings.centerY.value : m_tempSettings.centerY.value;
        centerY.y = m_toSettings != null && m_toSettings.active && m_toSettings.centerY.overrideState ? m_toSettings.centerY.value : m_tempSettings.centerY.value;

        //scale
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.scale.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.scale.overrideState))
        {
            m_tempSettings.scale.overrideState = true;
        }
        else
        {
            m_tempSettings.scale.overrideState = false;
        }
        scale.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.scale.overrideState ? m_fromSettings.scale.value : m_tempSettings.scale.value;
        scale.y = m_toSettings != null && m_toSettings.active && m_toSettings.scale.overrideState ? m_toSettings.scale.value : m_tempSettings.scale.value;
    }

    public override void Lerp(float value)
    {
        if(!IsValid())
        {
            return;
        }

        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, value);
        m_tempSettings.intensityX.value = Mathf.Lerp(intensityX.x, intensityX.y, value);
        m_tempSettings.intensityY.value = Mathf.Lerp(intensityY.x, intensityY.y, value);
        m_tempSettings.centerX.value = Mathf.Lerp(centerX.x, centerX.y, value);
        m_tempSettings.centerY.value = Mathf.Lerp(centerY.x, centerY.y, value);
        m_tempSettings.scale.value = Mathf.Lerp(scale.x, scale.y, value);
    }
}
