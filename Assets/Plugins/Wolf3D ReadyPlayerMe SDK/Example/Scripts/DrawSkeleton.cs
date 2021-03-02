using UnityEngine;

public class DrawSkeleton : MonoBehaviour
{
    [SerializeField] private Transform rootBone;

    private void OnDrawGizmos()
    {
        if(rootBone != null)
        {
            DrawBone(rootBone);
        }
    }

    private void DrawBone(Transform root)
    {
        Gizmos.color = Color.white;
        foreach (Transform bone in root)
        {
            Gizmos.DrawLine(root.position, bone.position);
            DrawBone(bone);
        }
    }
}
