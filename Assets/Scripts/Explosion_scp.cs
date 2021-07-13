using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_scp : MonoBehaviour
{
    private AudioSource Explosion_audio;
    void Start()
    {
        Explosion_audio.Play(0);
        Destroy(this.gameObject, 3.0f);
        Explosion_audio = GetComponent<AudioSource>();
    }

}
