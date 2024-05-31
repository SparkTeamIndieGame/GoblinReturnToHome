#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CreatingLvl))]
public class CreatingLvlEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        CreatingLvl cl = (CreatingLvl)target;
        if (GUILayout.Button("Create Platform")) cl.Create();
        //if (GUILayout.Button("Random")) cl.RandomCreat();
        //if (GUILayout.Button("Delete")) cl.Delete();
        //if (GUILayout.Button("Full random")) cl.FullRandom();
    }
}
#endif
