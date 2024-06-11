#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CreatingLvl))]
public class CreatingLvlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CreatingLvl cl = (CreatingLvl)target;
        if (GUILayout.Button("Crate Full Lvl!")) cl.CreateFullLvlAutomatycly();
        if (GUILayout.Button("Destroy All")) cl.DestroyAll();
    }
}
#endif
