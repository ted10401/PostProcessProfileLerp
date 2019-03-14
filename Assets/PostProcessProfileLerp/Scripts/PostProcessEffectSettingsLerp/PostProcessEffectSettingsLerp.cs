using UnityEngine.Rendering.PostProcessing;

public abstract class PostProcessEffectSettingsLerp<T> where T : PostProcessEffectSettings
{
    private bool m_isValid;
    protected T m_fromSettings;
    protected T m_toSettings;
    protected T m_tempSettings;

    public PostProcessEffectSettingsLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp)
    {
        from.TryGetSettings(out m_fromSettings);
        to.TryGetSettings(out m_toSettings);

        if ((m_fromSettings != null && m_fromSettings.active) ||
            (m_toSettings != null && m_toSettings.active))
        {
            temp.TryGetSettings(out m_tempSettings);
            if (m_tempSettings == null)
            {
                m_tempSettings = temp.AddSettings<T>();
            }

            m_isValid = true;
            m_tempSettings.active = true;
        }

        if(m_isValid)
        {
            InitializeParameters();
        }
    }

    public void Destroy()
    {
        m_fromSettings = null;
        m_toSettings = null;
        m_tempSettings = null;
    }

    public abstract void InitializeParameters();
    public abstract void Lerp(float t);

    protected bool IsValid()
    {
        return m_isValid;
    }
}
