using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MotionBlurLerp : PostProcessEffectSettingsLerp<MotionBlur>
{
    public Vector2 shutterAngle;
    public Vector2 sampleCount;

    public MotionBlurLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //shutterAngle
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.shutterAngle.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.shutterAngle.overrideState))
        {
            m_tempSettings.shutterAngle.overrideState = true;
        }
        else
        {
            m_tempSettings.shutterAngle.overrideState = false;
        }
        shutterAngle.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.shutterAngle.overrideState ? m_fromSettings.shutterAngle.value : m_tempSettings.shutterAngle.value;
        shutterAngle.y = m_toSettings != null && m_toSettings.active && m_toSettings.shutterAngle.overrideState ? m_toSettings.shutterAngle.value : m_tempSettings.shutterAngle.value;

        //sampleCount
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.sampleCount.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.sampleCount.overrideState))
        {
            m_tempSettings.sampleCount.overrideState = true;
        }
        else
        {
            m_tempSettings.sampleCount.overrideState = false;
        }
        sampleCount.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.sampleCount.overrideState ? m_fromSettings.sampleCount.value : m_tempSettings.sampleCount.value;
        sampleCount.y = m_toSettings != null && m_toSettings.active && m_toSettings.sampleCount.overrideState ? m_toSettings.sampleCount.value : m_tempSettings.sampleCount.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.shutterAngle.value = Mathf.Lerp(shutterAngle.x, shutterAngle.y, t);
        m_tempSettings.sampleCount.value = (int)Mathf.Lerp(sampleCount.x, sampleCount.y, t);
    }
}
