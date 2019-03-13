using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationTransition : BaseTransition<ChromaticAberration>
{
    public Vector2 m_intensity;

    public ChromaticAberrationTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
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
        m_intensity.x = m_fromSettings == null ? 0f : m_fromSettings.intensity.value;
        m_intensity.y = m_toSettings == null ? 0f : m_toSettings.intensity.value;

        //fastMode
        if ((m_fromSettings != null && m_fromSettings.fastMode.overrideState) ||
            (m_toSettings != null && m_toSettings.fastMode.overrideState))
        {
            m_tempSettings.fastMode.overrideState = true;

            if (m_toSettings != null)
            {
                m_tempSettings.fastMode.value = m_toSettings.fastMode.value;
            }
            else if (m_fromSettings != null)
            {
                m_tempSettings.fastMode.value = m_fromSettings.fastMode.value;
            }
        }
        else
        {
            m_tempSettings.fastMode.overrideState = false;
        }
    }

    public override void Lerp(float value)
    {
        m_tempSettings.intensity.value = Mathf.Lerp(m_intensity.x, m_intensity.y, value);
    }
}
