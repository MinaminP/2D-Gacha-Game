using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GachaManager))]
public class GachaManagerEditor : Editor
{
    public int Common, Rare, SuperRare;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        GachaManager gm = (GachaManager)target;

        Common = EditorGUILayout.IntField("Common", (gm.Rates(Rarity.Common) - gm.Rates(Rarity.Rare)));
        Rare = EditorGUILayout.IntField("Rare", (gm.Rates(Rarity.Rare) - gm.Rates(Rarity.SuperRare)));
        SuperRare = EditorGUILayout.IntField("SuperRare", gm.Rates(Rarity.SuperRare));
    }
}
