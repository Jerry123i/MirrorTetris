using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeAudioControler : MonoBehaviour
{

    AudioSource source;
    public List<AudioClip> hitGroudSolid;
    public List<AudioClip> hitGroundDrawing;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    public void PlayHitGroundSolid()
    {
        source.clip = hitGroudSolid[Random.Range(0,hitGroudSolid.Count)];
        source.pitch = Random.Range(0.5f, 1.5f);
        source.Play();
    }

    public void PlayHitGroundDrawing()
    {
        source.clip = hitGroundDrawing[Random.Range(0,hitGroundDrawing.Count)];
        source.pitch = Random.Range(0.9f, 1.5f);
        source.Play();
    }

}
