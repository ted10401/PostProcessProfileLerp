using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GrainTransition : BaseTransition<Grain>
{
    public bool defaultColored;
    public Vector2 intensity;
    public Vector2 size;
    public Vector2 lumContrib;

    public GrainTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        defaultColored = m_tempSettings.colored.value;

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
        intensity.x = m_fromSettings == null ? m_tempSettings.intensity.value : m_fromSettings.intensity.value;
        intensity.y = m_toSettings == null ? m_tempSettings.intensity.value : m_toSettings.intensity.value;

        //size
        if ((m_fromSettings != null && m_fromSettings.size.overrideState) ||
            (m_toSettings != null && m_toSettings.size.overrideState))
        {
            m_tempSettings.size.overrideState = true;
        }
        else
        {
            m_tempSettings.size.overrideState = false;
        }
        size.x = m_fromSettings == null ? m_tempSettings.size.value : m_fromSettings.size.value;
        size.y = m_toSettings == null ? m_tempSettings.size.value : m_toSettings.size.value;

        //lumContrib
        if ((m_fromSettings != null && m_fromSettings.lumContrib.overrideState) ||
            (m_toSettings != null && m_toSettings.lumContrib.overrideState))
        {
            m_tempSettings.lumContrib.overrideState = true;
        }
        else
        {
            m_tempSettings.lumContrib.overrideState = false;
        }
        lumContrib.x = m_fromSettings == null ? m_tempSettings.lumContrib.value : m_fromSettings.lumContrib.value;
        lumContrib.y = m_toSettings == null ? m_tempSettings.lumContrib.value : m_toSettings.lumContrib.value;
    }

    public override void Lerp(float value)
    {
        if(!IsValid())
        {
            return;
        }

        //colored
        if ((m_fromSettings != null && m_fromSettings.colored.overrideState) ||
            (m_toSettings != null && m_toSettings.colored.overrideState))
        {
            m_tempSettings.colored.overrideState = true;

            if (value < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.colored.value = m_fromSettings.colored.value;
                }
                else
                {
                    m_tempSettings.colored.value = defaultColored;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.colored.value = m_toSettings.colored.value;
                }
                else
                {
                    m_tempSettings.colored.value = defaultColored;
                }
            }
        }
        else
        {
            m_tempSettings.colored.overrideState = false;
        }

        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, value);
        m_tempSettings.size.value = Mathf.Lerp(size.x, size.y, value);
        m_tempSettings.lumContrib.value = Mathf.Lerp(lumContrib.x, lumContrib.y, value);
    }
}
