using UnityEngine.Rendering.PostProcessing;

public static class PostProcessProfileUtils
{
    public static void Transition(this PostProcessVolume postProcessVolume, PostProcessProfile postProcessProfile, float duration) => new PostProcessTransition(postProcessVolume, postProcessProfile, duration);
}
