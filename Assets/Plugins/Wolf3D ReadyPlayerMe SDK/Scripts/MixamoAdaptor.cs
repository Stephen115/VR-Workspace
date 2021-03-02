using UnityEngine;

namespace Wolf3D.ReadyPlayerMe.AvatarSDK
{
    public class MixamoAdaptor : MonoBehaviour
    {
        public RuntimeAnimatorController Animator { get; set; }
        public UnityEngine.Avatar AnimatorAvatar { get; set; }

        private void Start()
        {
            GameObject armature = new GameObject();
            armature.name = "Armature";

            armature.transform.parent = transform;
            armature.transform.localScale *= 0.01f;

            Transform hips = transform.Find("Hips");
            hips.parent = armature.transform;

            Animator animator = armature.AddComponent<Animator>();
            animator.runtimeAnimatorController = Animator;
            animator.avatar = AnimatorAvatar;
            animator.applyRootMotion = true;
        }
    }
}