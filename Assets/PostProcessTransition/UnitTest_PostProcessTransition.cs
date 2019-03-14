using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class UnitTest_PostProcessTransition : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    public float duration;

    private PostProcessVolume m_postProcessVolume;
    private PostProcessTransition m_postProcessTransition;
    private Tweener m_tweener;

    private void Awake()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(m_postProcessVolume != null)
            {
                m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, postProcessProfileA, duration);
                DOTween.To(OnTransitionUpdate, 0f, 1f, duration).OnComplete(OnTransitionComplete);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (m_postProcessVolume != null)
            {
                m_postProcessTransition = new PostProcessTransition(m_postProcessVolume, postProcessProfileB, duration);
                DOTween.To(OnTransitionUpdate, 0f, 1f, duration).OnComplete(OnTransitionComplete);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DOTween.To(OnTestUpdate, 0f, 1f, duration);
        }
    }

    private void OnTransitionUpdate(float value)
    {
        Debug.LogError(value);

        if(m_postProcessTransition != null)
        {
            m_postProcessTransition.Lerp(value);
        }
    }

    private void OnTestUpdate(float value)
    {
        Debug.LogError(value);
    }

    private void OnTransitionComplete()
    {
        if (m_postProcessTransition != null)
        {
            m_postProcessTransition.Destroy();
            m_postProcessTransition = null;
        }

        if(m_tweener != null)
        {
            m_tweener.Kill();
            m_tweener = null;
        }
    }
}
