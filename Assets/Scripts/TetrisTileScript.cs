using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisTileScript : MonoBehaviour {

    public int x;
    public int y;

    public bool full;
    public bool isOnTheBlueprint;

    public GameObject thing;

    private SpriteRenderer sprite;

    public Sprite normal;
    public Sprite bluePrint;

    public TileAudioControler tileAudio;

    private void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        tileAudio = this.GetComponent<TileAudioControler>();
    }

    public void ClearTile()
    {
        if (full)
        {
            if (thing.GetComponent<QuadradoScript>().shape != null)
            {
                Destroy(thing.GetComponent<QuadradoScript>().shape);
            }
        }

        isOnTheBlueprint = false;
        full = false;
        
        Destroy(thing);

        sprite.sprite = normal;
    }

    public void ReadyBlueprint()
    {
        if (full)
        {
            MakeBlueprint();
        }
    }

    public void MakeBlueprint()
    {
        isOnTheBlueprint = true;
        
        if (full)
        {
            if (thing.GetComponent<QuadradoScript>().shape != null)
            {
                Destroy(thing.GetComponent<QuadradoScript>().shape);
            }
        }

        Destroy(thing);
        full = false;

        sprite.sprite = bluePrint;
    }

}
