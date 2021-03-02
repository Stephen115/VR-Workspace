using UnityEditor;
using UnityEngine;
using Wolf3D.ReadyPlayerMe.Example;

[CustomEditor(typeof(AvatarLoaderExample))]
public class AvatarLoaderExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AvatarLoaderExample loader = target as AvatarLoaderExample;

        GUILayout.Space(10);

        if (GUILayout.Button("Load Avatar"))
        {
            loader.LoadAvatar();
        }
    }
}
