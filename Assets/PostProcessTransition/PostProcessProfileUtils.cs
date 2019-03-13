using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public static class PostProcessProfileUtils
{
    public static PostProcessProfile Lerp(PostProcessProfile postProcessProfileA, PostProcessProfile postProcessProfileB, float lerp)
    {
        PostProcessProfile postProcessProfile = Object.Instantiate(postProcessProfileA);
        new BloomTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new AmbientOcclusionTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new AutoExposureTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new ChromaticAberrationTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);
        new ColorGradingTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Lerp(lerp);

        return postProcessProfile;
    }

    public static void Transition(this PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration) => new PostProcessTransition(postProcessVolume, postProcessProfile, duration);
}
