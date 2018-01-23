using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuilderScheme))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuilderScheme data = (BuilderScheme)target;

        

        GUILayout.BeginHorizontal();

        EditorGUILayout.TextArea("Numero de Peças:");
        data.maxPieces = (int)EditorGUILayout.IntField(data.maxPieces);
        EditorGUILayout.TextArea("Recomendado: " + ((int)(CountActiveTiles(data)/4)).ToString());

        GUILayout.EndHorizontal();

        if (data.woke)
        {

            for (int j = data.y - 1; j >= 0; j--)
            {

                GUILayout.BeginHorizontal();

                for (int i = 0; i < data.x; i++)
                {

                    data.blueprint[i, j] = (bool)EditorGUILayout.Toggle(data.blueprint[i, j]);
                }

                GUILayout.EndHorizontal();

            }

        }

        else
        {
            if (GUILayout.Button("Initialize", EditorStyles.miniButtonRight))
            {
                data.EnableArray();
                Debug.Log("data.EnableArray() ... ");
            }
        }

        if (CountActiveTiles(data) % 4 > 0)
        {
            EditorGUILayout.TextArea("!!!NÃO MULTIPLO DE 4!!!");
        }

        EditorUtility.SetDirty(target);
    }

    int CountActiveTiles(BuilderScheme build)
    {

        int count = 0;

        for (int j = build.y - 1; j >= 0; j--)
        {
            for (int i = 0; i < build.x; i++)
            {

                if (build.blueprint[i, j])
                {
                    count++;
                }
                
            }

        }

        return count;

    }

}