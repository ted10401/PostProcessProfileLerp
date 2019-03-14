using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessProfileTween : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    public float duration;

    private PostProcessVolume m_postProcessVolume;
    private PostProcessProfileTween m_postProcessProfileTween;

    private void Start()
    {
        m_postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(m_postProcessProfileTween != null)
            {
                m_postProcessProfileTween.Kill();
                m_postProcessProfileTween = null;
            }

            m_postProcessProfileTween = m_postProcessVolume.To(postProcessProfileA, duration);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (m_postProcessProfileTween != null)
            {
                m_postProcessProfileTween.Kill();
                m_postProcessProfileTween = null;
            }

            m_postProcessProfileTween = m_postProcessVolume.To(postProcessProfileB, duration);
        }
    }
}
