using UnityEngine;

namespace Wolf3D.ReadyPlayerMe.AvatarSDK
{
    [DisallowMultipleComponent]
    public class EyeRotator : MonoBehaviour
    {
        private const int VerticalMargin = 3;
        private const int HorizontalMargin = 10;

        private Transform leftEyeBone;
        private const string HalfbodyLeftEyeBoneName = "Armature/Hips/Spine/Neck/Head/LeftEye";
        private const string FullbodyLeftEyeBoneName = "Armature/Hips/Spine/Spine1/Spine2/Neck/Head/LeftEye";

        private Transform rightEyeBone;
        private const string HalfbodyRightEyeBoneName = "Armature/Hips/Spine/Neck/Head/RightEye";
        private const string FullbodyRightEyeBoneName = "Armature/Hips/Spine/Spine1/Spine2/Neck/Head/RightEye";

        private int horizontalPadding = 0;

        private void Start()
        {
            bool isFullbody = transform.Find("Armature/Hips/LeftUpLeg");

            leftEyeBone = transform.Find(isFullbody ? FullbodyLeftEyeBoneName : HalfbodyLeftEyeBoneName);
            rightEyeBone = transform.Find(isFullbody ? FullbodyRightEyeBoneName : HalfbodyRightEyeBoneName);

            horizontalPadding = isFullbody ? 0 : -90;

            InvokeRepeating(nameof(RotateEyes), 1, 3);
        }

        private void RotateEyes()
        {
            float vertical = Random.Range(-VerticalMargin, VerticalMargin);
            float horizontal = Random.Range(-HorizontalMargin, HorizontalMargin);

            Quaternion rotation = Quaternion.Euler(horizontal + horizontalPadding, 0, 180 + vertical);

            leftEyeBone.localRotation = rotation;
            rightEyeBone.localRotation = rotation;
        }
    }
}