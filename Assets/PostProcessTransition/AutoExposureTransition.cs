using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AutoExposureTransition : BaseTransition<AutoExposure>
{
    private Vector2 m_fromFiltering;
    private Vector2 m_toFiltering;
    private Vector2 m_minLuminance;
    private Vector2 m_maxLuminance;
    private Vector2 m_keyValue;
    private Vector2 m_speedUp;
    private Vector2 m_speedDown;

    public AutoExposureTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //filtering
        if ((m_fromSettings != null && m_fromSettings.filtering.overrideState) ||
            (m_toSettings != null && m_toSettings.filtering.overrideState))
        {
            m_tempSettings.filtering.overrideState = true;
        }
        else
        {
            m_tempSettings.filtering.overrideState = false;
        }
        m_fromFiltering = m_fromSettings == null ? Vector2.zero : m_fromSettings.filtering.value;
        m_toFiltering = m_toSettings == null ? Vector2.zero : m_toSettings.filtering.value;

        //minLuminance
        if ((m_fromSettings != null && m_fromSettings.minLuminance.overrideState) ||
            (m_toSettings != null && m_toSettings.minLuminance.overrideState))
        {
            m_tempSettings.minLuminance.overrideState = true;
        }
        else
        {
            m_tempSettings.minLuminance.overrideState = false;
        }
        m_minLuminance.x = m_fromSettings == null ? 0f : m_fromSettings.minLuminance.value;
        m_minLuminance.y = m_toSettings == null ? 0f : m_toSettings.minLuminance.value;

        //maxLuminance
        if ((m_fromSettings != null && m_fromSettings.maxLuminance.overrideState) ||
            (m_toSettings != null && m_toSettings.maxLuminance.overrideState))
        {
            m_tempSettings.maxLuminance.overrideState = true;
        }
        else
        {
            m_tempSettings.maxLuminance.overrideState = false;
        }
        m_maxLuminance.x = m_fromSettings == null ? 0f : m_fromSettings.maxLuminance.value;
        m_maxLuminance.y = m_toSettings == null ? 0f : m_toSettings.maxLuminance.value;

        //keyValue
        if ((m_fromSettings != null && m_fromSettings.keyValue.overrideState) ||
            (m_toSettings != null && m_toSettings.keyValue.overrideState))
        {
            m_tempSettings.keyValue.overrideState = true;
        }
        else
        {
            m_tempSettings.keyValue.overrideState = false;
        }
        m_keyValue.x = m_fromSettings == null ? 0f : m_fromSettings.keyValue.value;
        m_keyValue.y = m_toSettings == null ? 0f : m_toSettings.keyValue.value;

        //eyeAdaptation
        if ((m_fromSettings != null && m_fromSettings.eyeAdaptation.overrideState) ||
            (m_toSettings != null && m_toSettings.eyeAdaptation.overrideState))
        {
            m_tempSettings.eyeAdaptation.overrideState = true;

            if (m_toSettings != null)
            {
                m_tempSettings.eyeAdaptation.value = m_toSettings.eyeAdaptation.value;
            }
            else if (m_fromSettings != null)
            {
                m_tempSettings.eyeAdaptation.value = m_fromSettings.eyeAdaptation.value;
            }
        }
        else
        {
            m_tempSettings.eyeAdaptation.overrideState = false;
        }

        //speedUp
        if ((m_fromSettings != null && m_fromSettings.speedUp.overrideState) ||
            (m_toSettings != null && m_toSettings.speedUp.overrideState))
        {
            m_tempSettings.speedUp.overrideState = true;
        }
        else
        {
            m_tempSettings.speedUp.overrideState = false;
        }
        m_speedUp.x = m_fromSettings == null ? 0f : m_fromSettings.speedUp.value;
        m_speedUp.y = m_toSettings == null ? 0f : m_toSettings.speedUp.value;

        //speedDown
        if ((m_fromSettings != null && m_fromSettings.speedDown.overrideState) ||
            (m_toSettings != null && m_toSettings.speedDown.overrideState))
        {
            m_tempSettings.speedDown.overrideState = true;
        }
        else
        {
            m_tempSettings.speedDown.overrideState = false;
        }
        m_speedDown.x = m_fromSettings == null ? 0f : m_fromSettings.speedDown.value;
        m_speedDown.y = m_toSettings == null ? 0f : m_toSettings.speedDown.value;
    }

    public override void Lerp(float value)
    {
        m_tempSettings.filtering.value = Vector2.Lerp(m_fromFiltering, m_toFiltering, value);
        m_tempSettings.minLuminance.value = Mathf.Lerp(m_minLuminance.x, m_minLuminance.y, value);
        m_tempSettings.maxLuminance.value = Mathf.Lerp(m_maxLuminance.x, m_minLuminance.y, value);
        m_tempSettings.keyValue.value = Mathf.Lerp(m_keyValue.x, m_keyValue.y, value);
        m_tempSettings.speedUp.value = Mathf.Lerp(m_speedUp.x, m_speedUp.y, value);
        m_tempSettings.speedDown.value = Mathf.Lerp(m_speedDown.x, m_speedDown.y, value);
    }
}
