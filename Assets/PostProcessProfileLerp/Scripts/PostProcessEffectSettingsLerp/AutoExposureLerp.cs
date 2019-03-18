using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AutoExposureLerp : PostProcessEffectSettingsLerp<AutoExposure>
{
    public Vector2 fromFiltering;
    public Vector2 toFiltering;
    public Vector2 minLuminance;
    public Vector2 maxLuminance;
    public Vector2 keyValue;
    public EyeAdaptation fromEyeAdaptation;
    public EyeAdaptation toEyeAdaptation;
    public Vector2 speedUp;
    public Vector2 speedDown;

    public AutoExposureLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //filtering
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.filtering.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.filtering.overrideState))
        {
            m_tempSettings.filtering.overrideState = true;
        }
        else
        {
            m_tempSettings.filtering.overrideState = false;
        }
        fromFiltering = m_fromSettings != null && m_fromSettings.active && m_fromSettings.filtering.overrideState ? m_fromSettings.filtering.value : m_tempSettings.filtering.value;
        toFiltering = m_toSettings != null && m_toSettings.active && m_toSettings.filtering.overrideState ? m_toSettings.filtering.value : m_tempSettings.filtering.value;

        //minLuminance
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.minLuminance.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.minLuminance.overrideState))
        {
            m_tempSettings.minLuminance.overrideState = true;
        }
        else
        {
            m_tempSettings.minLuminance.overrideState = false;
        }
        minLuminance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.minLuminance.overrideState ? m_fromSettings.minLuminance.value : m_tempSettings.minLuminance.value;
        minLuminance.y = m_toSettings != null && m_toSettings.active && m_toSettings.minLuminance.overrideState ? m_toSettings.minLuminance.value : m_tempSettings.minLuminance.value;

        //maxLuminance
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.maxLuminance.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.maxLuminance.overrideState))
        {
            m_tempSettings.maxLuminance.overrideState = true;
        }
        else
        {
            m_tempSettings.maxLuminance.overrideState = false;
        }
        maxLuminance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.maxLuminance.overrideState ? m_fromSettings.maxLuminance.value : m_tempSettings.maxLuminance.value;
        maxLuminance.y = m_toSettings != null && m_toSettings.active && m_toSettings.maxLuminance.overrideState ? m_toSettings.maxLuminance.value : m_tempSettings.maxLuminance.value;

        //keyValue
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.keyValue.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.keyValue.overrideState))
        {
            m_tempSettings.keyValue.overrideState = true;
        }
        else
        {
            m_tempSettings.keyValue.overrideState = false;
        }
        keyValue.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.keyValue.overrideState ? m_fromSettings.keyValue.value : m_tempSettings.keyValue.value;
        keyValue.y = m_toSettings != null && m_toSettings.active && m_toSettings.keyValue.overrideState ? m_toSettings.keyValue.value : m_tempSettings.keyValue.value;

        //eyeAdaptation
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.eyeAdaptation.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.eyeAdaptation.overrideState))
        {
            m_tempSettings.eyeAdaptation.overrideState = true;
        }
        else
        {
            m_tempSettings.eyeAdaptation.overrideState = false;
        }
        fromEyeAdaptation = m_fromSettings != null && m_fromSettings.active && m_fromSettings.eyeAdaptation.overrideState ? m_fromSettings.eyeAdaptation.value : m_tempSettings.eyeAdaptation.value;
        toEyeAdaptation = m_toSettings != null && m_toSettings.active && m_toSettings.eyeAdaptation.overrideState ? m_toSettings.eyeAdaptation.value : m_tempSettings.eyeAdaptation.value;

        //speedUp
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.speedUp.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.speedUp.overrideState))
        {
            m_tempSettings.speedUp.overrideState = true;
        }
        else
        {
            m_tempSettings.speedUp.overrideState = false;
        }
        speedUp.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.speedUp.overrideState ? m_fromSettings.speedUp.value : m_tempSettings.speedUp.value;
        speedUp.y = m_toSettings != null && m_toSettings.active && m_toSettings.speedUp.overrideState ? m_toSettings.speedUp.value : m_tempSettings.speedUp.value;

        //speedDown
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.speedDown.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.speedDown.overrideState))
        {
            m_tempSettings.speedDown.overrideState = true;
        }
        else
        {
            m_tempSettings.speedDown.overrideState = false;
        }
        speedDown.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.speedDown.overrideState ? m_fromSettings.speedDown.value : m_tempSettings.speedDown.value;
        speedDown.y = m_toSettings != null && m_toSettings.active && m_toSettings.speedDown.overrideState ? m_toSettings.speedDown.value : m_tempSettings.speedDown.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.filtering.Interp(fromFiltering, toFiltering, t);
        m_tempSettings.minLuminance.Interp(minLuminance.x, minLuminance.y, t);
        m_tempSettings.maxLuminance.Interp(maxLuminance.x, maxLuminance.y, t);
        m_tempSettings.keyValue.Interp(keyValue.x, keyValue.y, t);
        m_tempSettings.eyeAdaptation.Interp(fromEyeAdaptation, toEyeAdaptation, t);
        m_tempSettings.speedUp.Interp(speedUp.x, speedUp.y, t);
        m_tempSettings.speedDown.Interp(speedDown.x, speedDown.y, t);
    }
}
