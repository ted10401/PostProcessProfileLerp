using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationLerp : PostProcessEffectSettingsLerp<ChromaticAberration>
{
    public Texture fromSpectralLut;
    public Texture toSpectralLut;
    public Vector2 intensity;
    public bool fromFastMode;
    public bool toFastMode;

    public ChromaticAberrationLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //spectralLut
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.spectralLut.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.spectralLut.overrideState))
        {
            m_tempSettings.spectralLut.overrideState = true;
        }
        else
        {
            m_tempSettings.spectralLut.overrideState = false;
        }
        fromSpectralLut = m_fromSettings != null && m_fromSettings.active && m_fromSettings.spectralLut.overrideState ? m_fromSettings.spectralLut.value : m_tempSettings.spectralLut.value;
        toSpectralLut = m_toSettings != null && m_toSettings.active && m_toSettings.spectralLut.overrideState ? m_toSettings.spectralLut.value : m_tempSettings.spectralLut.value;

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

        //fastMode
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.fastMode.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.fastMode.overrideState))
        {
            m_tempSettings.fastMode.overrideState = true;
        }
        else
        {
            m_tempSettings.fastMode.overrideState = false;
        }
        fromFastMode = m_fromSettings != null && m_fromSettings.active && m_fromSettings.fastMode.overrideState ? m_fromSettings.fastMode.value : m_tempSettings.fastMode.value;
        toFastMode = m_toSettings != null && m_toSettings.active && m_toSettings.fastMode.overrideState ? m_toSettings.fastMode.value : m_tempSettings.fastMode.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.spectralLut.Interp(fromSpectralLut, toSpectralLut, t);
        m_tempSettings.intensity.Interp(intensity.x, intensity.y, t);
        m_tempSettings.fastMode.Interp(fromFastMode, toFastMode, t);
    }
}
