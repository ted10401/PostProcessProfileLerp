using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AutoExposureTransition : BaseTransition<AutoExposure>
{
    public Vector2 fromFiltering;
    public Vector2 toFiltering;
    public Vector2 minLuminance;
    public Vector2 maxLuminance;
    public Vector2 keyValue;
    public Vector2 speedUp;
    public Vector2 speedDown;

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
        fromFiltering = m_fromSettings == null ? Vector2.zero : m_fromSettings.filtering.value;
        toFiltering = m_toSettings == null ? Vector2.zero : m_toSettings.filtering.value;

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
        minLuminance.x = m_fromSettings == null ? 0f : m_fromSettings.minLuminance.value;
        minLuminance.y = m_toSettings == null ? 0f : m_toSettings.minLuminance.value;

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
        maxLuminance.x = m_fromSettings == null ? 0f : m_fromSettings.maxLuminance.value;
        maxLuminance.y = m_toSettings == null ? 0f : m_toSettings.maxLuminance.value;

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
        keyValue.x = m_fromSettings == null ? 0f : m_fromSettings.keyValue.value;
        keyValue.y = m_toSettings == null ? 0f : m_toSettings.keyValue.value;

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
        speedUp.x = m_fromSettings == null ? 0f : m_fromSettings.speedUp.value;
        speedUp.y = m_toSettings == null ? 0f : m_toSettings.speedUp.value;

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
        speedDown.x = m_fromSettings == null ? 0f : m_fromSettings.speedDown.value;
        speedDown.y = m_toSettings == null ? 0f : m_toSettings.speedDown.value;
    }

    public override void Lerp(float value)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.filtering.value = Vector2.Lerp(fromFiltering, toFiltering, value);
        m_tempSettings.minLuminance.value = Mathf.Lerp(minLuminance.x, minLuminance.y, value);
        m_tempSettings.maxLuminance.value = Mathf.Lerp(maxLuminance.x, minLuminance.y, value);
        m_tempSettings.keyValue.value = Mathf.Lerp(keyValue.x, keyValue.y, value);

        //eyeAdaptation
        if ((m_fromSettings != null && m_fromSettings.eyeAdaptation.overrideState) ||
            (m_toSettings != null && m_toSettings.eyeAdaptation.overrideState))
        {
            m_tempSettings.eyeAdaptation.overrideState = true;

            if(value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.eyeAdaptation.value = m_fromSettings.eyeAdaptation.value;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.eyeAdaptation.value = m_toSettings.eyeAdaptation.value;
                }
            }
        }
        else
        {
            m_tempSettings.eyeAdaptation.overrideState = false;
        }

        m_tempSettings.speedUp.value = Mathf.Lerp(speedUp.x, speedUp.y, value);
        m_tempSettings.speedDown.value = Mathf.Lerp(speedDown.x, speedDown.y, value);
    }
}
