using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DepthOfFieldLerp : PostProcessEffectSettingsLerp<DepthOfField>
{
    public Vector2 focusDistance;
    public Vector2 aperture;
    public Vector2 focalLength;
    public KernelSizeParameter kernelSize;

    public DepthOfFieldLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //focusDistance
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.focusDistance.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.focusDistance.overrideState))
        {
            m_tempSettings.focusDistance.overrideState = true;
        }
        else
        {
            m_tempSettings.focusDistance.overrideState = false;
        }
        focusDistance.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.focusDistance.overrideState ? m_fromSettings.focusDistance.value : m_tempSettings.focusDistance.value;
        focusDistance.y = m_toSettings != null && m_toSettings.active && m_toSettings.focusDistance.overrideState ? m_toSettings.focusDistance.value : m_tempSettings.focusDistance.value;

        //aperture
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.aperture.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.aperture.overrideState))
        {
            m_tempSettings.aperture.overrideState = true;
        }
        else
        {
            m_tempSettings.aperture.overrideState = false;
        }
        aperture.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.aperture.overrideState ? m_fromSettings.aperture.value : m_tempSettings.aperture.value;
        aperture.y = m_toSettings != null && m_toSettings.active && m_toSettings.aperture.overrideState ? m_toSettings.aperture.value : m_tempSettings.aperture.value;

        //focalLength
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.focalLength.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.focalLength.overrideState))
        {
            m_tempSettings.focalLength.overrideState = true;
        }
        else
        {
            m_tempSettings.focalLength.overrideState = false;
        }
        focalLength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.focalLength.overrideState ? m_fromSettings.focalLength.value : m_tempSettings.focalLength.value;
        focalLength.y = m_toSettings != null && m_toSettings.active && m_toSettings.focalLength.overrideState ? m_toSettings.focalLength.value : m_tempSettings.focalLength.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.focusDistance.value = Mathf.Lerp(focusDistance.x, focusDistance.y, t);
        m_tempSettings.aperture.value = Mathf.Lerp(aperture.x, aperture.y, t);
        m_tempSettings.focalLength.value = Mathf.Lerp(focalLength.x, focalLength.y, t);

        //kernelSize
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.kernelSize.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.kernelSize.overrideState))
        {
            m_tempSettings.kernelSize.overrideState = true;

            if (t < 0.5f)
            {
                if (m_fromSettings != null)
                {
                    m_tempSettings.kernelSize.value = m_fromSettings.kernelSize.value;
                }
                else
                {
                    //m_tempSettings.kernelSize.value = false;
                }
            }
            else
            {
                if (m_toSettings != null)
                {
                    m_tempSettings.kernelSize.value = m_toSettings.kernelSize.value;
                }
                else
                {
                    //m_tempSettings.kernelSize.value = false;
                }
            }
        }
        else
        {
            m_tempSettings.kernelSize.overrideState = false;
        }
    }
}
