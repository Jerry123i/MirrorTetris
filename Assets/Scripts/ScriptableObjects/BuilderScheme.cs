using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Building", order = 1)]

[System.Serializable]
public class BuilderScheme : ScriptableObject
{

    [HideInInspector]
    public int x, y;

    public int maxPieces;

    [HideInInspector]
    public bool woke;

    [HideInInspector]
    public Blueprint blueprint;

    public void EnableArray()
    {
        blueprint = new Blueprint();
        x = blueprint.x;
        y = blueprint.y;
        woke = true;
    }

    [System.Serializable]
    public class Blueprint
    {
        public int x = 13, y = 20;

        [SerializeField]
        private bool[] data;

        public bool this[int i, int j]
        {
            get { return data[i * y + j]; }
            set { data[i * y + j] = value; }
        }

        public Blueprint()
        {
            data = new bool[x * y];
        }

    }

}



