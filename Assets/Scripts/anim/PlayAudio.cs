using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlayPrepAttackAud(){
        aud.Play();
    }
    public void test(float i){
        Debug.Log(i);
    }
}
