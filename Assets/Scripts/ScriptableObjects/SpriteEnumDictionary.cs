using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class SpriteEnumDictionary : MonoBehaviour{

    [SerializeField]
    public Dictionary<ShapeType, Sprite> spritesDictionary =
        new Dictionary<ShapeType, Sprite>();

}

[CustomEditor(typeof(SpriteEnumDictionary))]
public class SpriteEnumDictionaryEditor : Editor
{
    Sprite sprite;
    Object objectHolder;
    private ShapeType shapeType;
    bool initialized;

    public override void OnInspectorGUI()
    {
        SpriteEnumDictionary data = (SpriteEnumDictionary)target;
        
        if(!initialized)
        {
            if (GUILayout.Button("Initialize", EditorStyles.miniButtonRight))
            {
                StartEnum();
                sprite = new Sprite();
            }
        }

        else
        {
            GUILayout.BeginHorizontal();

            shapeType = (ShapeType)EditorGUILayout.EnumPopup("Shape Type:", shapeType);
            objectHolder = EditorGUILayout.ObjectField(objectHolder, typeof(Object), false);

            sprite = objectHolder as Sprite;

            GUILayout.EndHorizontal();

            if (GUILayout.Button("Add To Dictionary", EditorStyles.miniButtonRight))
            {
                data.spritesDictionary.Add(shapeType, sprite);
            }

            GUILayout.TextArea("Dictionary Size:" + data.spritesDictionary.Count.ToString());

        }
    }

    private void StartEnum()
    {
        shapeType = new ShapeType();
        initialized = true;
    }

}