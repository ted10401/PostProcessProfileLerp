using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GrainLerp : PostProcessEffectSettingsLerp<Grain>
{
    public bool fromColored;
    public bool toColored;
    public Vector2 intensity;
    public Vector2 size;
    public Vector2 lumContrib;

    public GrainLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //colored
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.colored.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.colored.overrideState))
        {
            m_tempSettings.colored.overrideState = true;
        }
        else
        {
            m_tempSettings.colored.overrideState = false;
        }
        fromColored = m_fromSettings != null && m_fromSettings.active && m_fromSettings.colored.overrideState ? m_fromSettings.colored.value : m_tempSettings.colored.value;
        toColored = m_toSettings != null && m_toSettings.active && m_toSettings.colored.overrideState ? m_toSettings.colored.value : m_tempSettings.colored.value;

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

        //size
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.size.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.size.overrideState))
        {
            m_tempSettings.size.overrideState = true;
        }
        else
        {
            m_tempSettings.size.overrideState = false;
        }
        size.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.size.overrideState ? m_fromSettings.size.value : m_tempSettings.size.value;
        size.y = m_toSettings != null && m_toSettings.active && m_toSettings.size.overrideState ? m_toSettings.size.value : m_tempSettings.size.value;

        //lumContrib
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.lumContrib.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.lumContrib.overrideState))
        {
            m_tempSettings.lumContrib.overrideState = true;
        }
        else
        {
            m_tempSettings.lumContrib.overrideState = false;
        }
        lumContrib.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.lumContrib.overrideState ? m_fromSettings.lumContrib.value : m_tempSettings.lumContrib.value;
        lumContrib.y = m_toSettings != null && m_toSettings.active && m_toSettings.lumContrib.overrideState ? m_toSettings.lumContrib.value : m_tempSettings.lumContrib.value;
    }

    public override void Lerp(float t)
    {
        if(!IsValid())
        {
            return;
        }

        m_tempSettings.colored.Interp(fromColored, toColored, t);
        m_tempSettings.intensity.Interp(intensity.x, intensity.y, t);
        m_tempSettings.size.Interp(size.x, size.y, t);
        m_tempSettings.lumContrib.Interp(lumContrib.x, lumContrib.y, t);
    }
}
