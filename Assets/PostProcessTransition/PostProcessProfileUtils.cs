using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessProfileUtils
{
    public static PostProcessProfile Lerp(PostProcessProfile postProcessProfileA, PostProcessProfile postProcessProfileB, float lerp)
    {
        PostProcessProfile postProcessProfile = Object.Instantiate(postProcessProfileA);
        new BloomTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new AmbientOcclusionTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new AutoExposureTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new ChromaticAberrationTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);

        return postProcessProfile;
    }
}
