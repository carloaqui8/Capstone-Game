using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sfxM, sfxR;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.clip = sfxM;
            source.Play();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            source.clip = sfxR;
            source.Play();
        }
        else { }
    }
}
