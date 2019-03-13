﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using System;

public class PostProcessTransition
{
    private Action m_onComplete;
    private PostProcessProfile m_tempProfile;
    private BloomTransition m_bloomTransition;
    private Tweener m_tweener;

    public PostProcessTransition(PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration, Action onComplete)
    {
        m_onComplete = onComplete;
        m_tempProfile = UnityEngine.Object.Instantiate(postProcessVolume.profile);
        m_bloomTransition = new BloomTransition(postProcessVolume.profile, postProcessProfile, m_tempProfile);
        postProcessVolume.profile = m_tempProfile;

        m_tweener = DOTween.To(OnTransitionUpdate, 0f, 1f, duration).OnComplete(OnTransitionComplete);
    }

    public void Destroy()
    {
        if(m_tweener != null)
        {
            m_tweener.Kill();
            m_tweener = null;
        }
    }

    private void OnTransitionUpdate(float value)
    {
        m_bloomTransition.Transition(value);
    }

    private void OnTransitionComplete()
    {
        m_tweener = null;
        if(m_onComplete != null)
        {
            m_onComplete();
        }
    }
}
