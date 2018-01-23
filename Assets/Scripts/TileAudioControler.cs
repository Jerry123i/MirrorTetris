using UnityEngine;
using System.Collections;

public class TileAudioControler : MonoBehaviour
{
    AudioSource source;

    public AudioClip pointsClip;
    public AudioClip badClip;
    public AudioClip emptyClip;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }
    
    public void PlayEmpty()
    {
        source.clip = emptyClip;
        source.Play();
    }

    public void PlayPoints()
    {
        source.clip = pointsClip;
        source.Play();
    }

    public void PlayBad()
    {
        source.clip = badClip;
        source.Play();
    }
}
