using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnitTest_PostProcessProfileLerp : MonoBehaviour
{
    public PostProcessProfile postProcessProfileA;
    public PostProcessProfile postProcessProfileB;
    [Range(0f, 1f)] public float lerp;

    private PostProcessVolume m_postProcessVolumn;

    private void Start()
    {
        m_postProcessVolumn = GetComponent<PostProcessVolume>();
    }

    private void OnValidate()
    {
        if(m_postProcessVolumn == null)
        {
            return;
        }

        if(postProcessProfileA == null || postProcessProfileB == null)
        {
            return;
        }

        m_postProcessVolumn.profile = PostProcessProfileUtility.Lerp(postProcessProfileA, postProcessProfileB, lerp);
    }
}
