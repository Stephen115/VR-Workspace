using UnityEngine;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

namespace Wolf3D.ReadyPlayerMe.Example
{
    public class AvatarLoaderExample : MonoBehaviour
    {
        #pragma warning disable 0649 
        [SerializeField] private string avatarUrl;

        [SerializeField] private bool cacheAvatarModels;

        [Header("Additional Components")]
        [SerializeField] private bool useEyeRotator;
        [SerializeField] private bool useVoiceToAnimation;
        #pragma warning restore 0649

        public void LoadAvatar()
        {
            AvatarLoader avatarLoader = new AvatarLoader();
            avatarLoader.UseModelCaching = cacheAvatarModels;
            avatarLoader.LoadAvatar(avatarUrl, OnAvatarLoaded);
        }

        // Callback that runs when avatar is loaded.
        private void OnAvatarLoaded(GameObject avatarObject)
        {
            Debug.Log("AvatarLoaderExample.OnAvatarLoaded: Avatar Loaded");

            if (useEyeRotator) avatarObject.AddComponent<EyeRotator>();
            if (useVoiceToAnimation) avatarObject.AddComponent<VoiceHandler>();
        }
    }
}
