using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationLerp : PostProcessEffectSettingsLerp<ChromaticAberration>
{
    public Vector2 intensity;

    public ChromaticAberrationLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
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
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        //spectralLut
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.spectralLut.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.spectralLut.overrideState))
        {
            m_tempSettings.spectralLut.overrideState = true;

            if (t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.spectralLut.value = m_fromSettings.spectralLut.value;
                }
                else
                {
                    m_tempSettings.spectralLut.value = null;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.spectralLut.value = m_toSettings.spectralLut.value;
                }
                else
                {
                    m_tempSettings.spectralLut.value = null;
                }
            }
        }
        else
        {
            m_tempSettings.spectralLut.overrideState = false;
        }

        m_tempSettings.intensity.value = Mathf.Lerp(intensity.x, intensity.y, t);

        //fastMode
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.fastMode.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.fastMode.overrideState))
        {
            m_tempSettings.fastMode.overrideState = true;

            if(t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.fastMode.value = m_fromSettings.fastMode.value;
                }
                else
                {
                    m_tempSettings.fastMode.value = false;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.fastMode.value = m_toSettings.fastMode.value;
                }
                else
                {
                    m_tempSettings.fastMode.value = false;
                }
            }
        }
        else
        {
            m_tempSettings.fastMode.overrideState = false;
        }
    }
}
