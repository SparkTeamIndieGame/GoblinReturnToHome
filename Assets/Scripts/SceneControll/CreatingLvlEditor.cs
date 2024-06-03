#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CreatingLvl))]
public class CreatingLvlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CreatingLvl cl = (CreatingLvl)target;
        if (GUILayout.Button("TakeLinks!#1")) cl.TakeLinks();
        if (GUILayout.Button("CreateSize!#2")) cl.CreateSize();
        if (GUILayout.Button("CreateDownPlatform!#3")) cl.CreateDownPlatform();
        if (GUILayout.Button("CreateUpPlatform!#4")) cl.CreateUpPlatform();

    }
}
#endif
