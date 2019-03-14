using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MotionBlurTransition : BaseTransition<MotionBlur>
{
    public Vector2 shutterAngle;
    public Vector2 sampleCount;

    public MotionBlurTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //shutterAngle
        if ((m_fromSettings != null && m_fromSettings.shutterAngle.overrideState) ||
            (m_toSettings != null && m_toSettings.shutterAngle.overrideState))
        {
            m_tempSettings.shutterAngle.overrideState = true;
        }
        else
        {
            m_tempSettings.shutterAngle.overrideState = false;
        }
        shutterAngle.x = m_fromSettings == null ? 0f : m_fromSettings.shutterAngle.value;
        shutterAngle.y = m_toSettings == null ? 0f : m_toSettings.shutterAngle.value;

        //sampleCount
        if ((m_fromSettings != null && m_fromSettings.sampleCount.overrideState) ||
            (m_toSettings != null && m_toSettings.sampleCount.overrideState))
        {
            m_tempSettings.sampleCount.overrideState = true;
        }
        else
        {
            m_tempSettings.sampleCount.overrideState = false;
        }
        sampleCount.x = m_fromSettings == null ? 0f : m_fromSettings.sampleCount.value;
        sampleCount.y = m_toSettings == null ? 0f : m_toSettings.sampleCount.value;
    }

    public override void Lerp(float value)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.shutterAngle.value = Mathf.Lerp(shutterAngle.x, shutterAngle.y, value);
        m_tempSettings.sampleCount.value = (int)Mathf.Lerp(sampleCount.x, sampleCount.y, value);
    }
}
