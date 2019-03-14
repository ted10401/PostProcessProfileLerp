using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public static class PostProcessTransitionUtils
{
    private const string TEMP_NAME = "PostProcessTransition";

    public static PostProcessProfile CreateInstance()
    {
        PostProcessProfile postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();
        postProcessProfile.name = TEMP_NAME;

        return postProcessProfile;
    }
}
