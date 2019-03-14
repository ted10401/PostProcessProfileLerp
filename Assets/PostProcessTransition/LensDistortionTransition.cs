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

        //intensityX
        if ((m_fromSettings != null && m_fromSettings.intensityX.overrideState) ||
            (m_toSettings != null && m_toSettings.intensityX.overrideState))
        {
            m_tempSettings.intensityX.overrideState = true;
        }
        else
        {
            m_tempSettings.intensityX.overrideState = false;
        }
        intensityX.x = m_fromSettings == null ? 0f : m_fromSettings.intensityX.value;
        intensityX.y = m_toSettings == null ? 0f : m_toSettings.intensityX.value;

        //intensityY
        if ((m_fromSettings != null && m_fromSettings.intensityY.overrideState) ||
            (m_toSettings != null && m_toSettings.intensityY.overrideState))
        {
            m_tempSettings.intensityY.overrideState = true;
        }
        else
        {
            m_tempSettings.intensityY.overrideState = false;
        }
        intensityY.x = m_fromSettings == null ? 0f : m_fromSettings.intensityY.value;
        intensityY.y = m_toSettings == null ? 0f : m_toSettings.intensityY.value;

        //centerX
        if ((m_fromSettings != null && m_fromSettings.centerX.overrideState) ||
            (m_toSettings != null && m_toSettings.centerX.overrideState))
        {
            m_tempSettings.centerX.overrideState = true;
        }
        else
        {
            m_tempSettings.centerX.overrideState = false;
        }
        centerX.x = m_fromSettings == null ? 0f : m_fromSettings.centerX.value;
        centerX.y = m_toSettings == null ? 0f : m_toSettings.centerX.value;

        //centerY
        if ((m_fromSettings != null && m_fromSettings.centerY.overrideState) ||
            (m_toSettings != null && m_toSettings.centerY.overrideState))
        {
            m_tempSettings.centerY.overrideState = true;
        }
        else
        {
            m_tempSettings.centerY.overrideState = false;
        }
        centerY.x = m_fromSettings == null ? 0f : m_fromSettings.centerY.value;
        centerY.y = m_toSettings == null ? 0f : m_toSettings.centerY.value;

        //scale
        if ((m_fromSettings != null && m_fromSettings.scale.overrideState) ||
            (m_toSettings != null && m_toSettings.scale.overrideState))
        {
            m_tempSettings.scale.overrideState = true;
        }
        else
        {
            m_tempSettings.scale.overrideState = false;
        }
        scale.x = m_fromSettings == null ? 0f : m_fromSettings.scale.value;
        scale.y = m_toSettings == null ? 0f : m_toSettings.scale.value;
    }

    public override void Lerp(float value)
    {
        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, value);
        m_tempSettings.intensityX.value = Mathf.Lerp(intensityX.x, intensityX.y, value);
        m_tempSettings.intensityY.value = Mathf.Lerp(intensityY.x, intensityY.y, value);
        m_tempSettings.centerX.value = Mathf.Lerp(centerX.x, centerX.y, value);
        m_tempSettings.centerY.value = Mathf.Lerp(centerY.x, centerY.y, value);
        m_tempSettings.scale.value = Mathf.Lerp(scale.x, scale.y, value);
    }
}
