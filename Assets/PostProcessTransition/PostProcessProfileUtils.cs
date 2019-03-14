using UnityEngine.Rendering.PostProcessing;

public static class PostProcessProfileUtils
{
    public static PostProcessProfile Lerp(PostProcessProfile a, PostProcessProfile b, float t) => new PostProcessProfileLerp(a, b).Lerp(t);
    public static PostProcessProfileTween To(this PostProcessVolume postProcessVolume, PostProcessProfile targetProfile, float duration) => new PostProcessProfileTween(postProcessVolume, targetProfile, duration);
}
