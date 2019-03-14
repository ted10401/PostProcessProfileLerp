using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class PostProcessProfileTween
{
    private PostProcessVolume m_postProcessVolumn;
    private PostProcessProfile m_targetProfile;
    private PostProcessProfileLerp m_postProcessProfileLerp;
    private Tweener m_tweener;

    public PostProcessProfileTween(PostProcessVolume postProcessVolume, PostProcessProfile targetProfile, float duration)
    {
        m_postProcessVolumn = postProcessVolume;
        m_targetProfile = targetProfile;
        m_postProcessProfileLerp = new PostProcessProfileLerp(postProcessVolume.profile, targetProfile);

        m_tweener = DOTween.To(OnTweenUpdate, 0f, 1f, duration).OnComplete(OnTweenComplete);
    }

    public void Kill()
    {
        m_postProcessVolumn = null;
        m_targetProfile = null;
        m_postProcessProfileLerp = null;

        if(m_tweener != null)
        {
            m_tweener.Kill();
            m_tweener = null;
        }
    }

    private void OnTweenUpdate(float value)
    {
        m_postProcessVolumn.profile = m_postProcessProfileLerp.Lerp(value);
    }

    private void OnTweenComplete()
    {
        m_postProcessVolumn.profile = m_targetProfile;
        m_postProcessVolumn = null;
        m_targetProfile = null;
        m_postProcessProfileLerp = null;
        m_tweener = null;
    }
}
