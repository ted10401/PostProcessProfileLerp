using UnityEngine.Rendering.PostProcessing;

public abstract class BaseTransition<T> where T : PostProcessEffectSettings
{
    protected T m_fromSettings;
    protected T m_toSettings;
    protected T m_tempSettings;

    public BaseTransition(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp)
    {
        from.TryGetSettings(out m_fromSettings);
        to.TryGetSettings(out m_toSettings);

        if ((m_fromSettings != null && m_fromSettings.enabled.value) ||
            (m_toSettings != null && m_toSettings.enabled.value))
        {
            temp.TryGetSettings(out m_tempSettings);
            if (m_tempSettings == null)
            {
                m_tempSettings = temp.AddSettings<T>();
            }

            m_tempSettings.enabled.value = true;
        }

        InitializeParameters();
    }

    public virtual void InitializeParameters()
    {

    }

    public virtual void Transition(float value)
    {

    }
}
