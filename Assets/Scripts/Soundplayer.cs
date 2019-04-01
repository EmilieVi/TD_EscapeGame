using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Soundplayer : MonoBehaviour {

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

}
