using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessProfileUtils
{
    public PostProcessProfile Lerp(PostProcessProfile postProcessProfileA, PostProcessProfile postProcessProfileB, float lerp)
    {
        PostProcessProfile postProcessProfile = Object.Instantiate(postProcessProfileA);
        new BloomTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Transition(lerp);
        new AmbientOcclusionTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Transition(lerp);
        new AutoExposureTransition(postProcessProfileA, postProcessProfileB, postProcessProfile).Transition(lerp);

        return postProcessProfile;
    }
}
