using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    public AudioClip[] soundtrack;
    AudioSource audioSource;
    
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying){
            PlayRandomSong();
        }
    }

    void PlayRandomSong()
    {
        int randomIndex = Random.Range(0, soundtrack.Length);
        audioSource.clip = soundtrack[randomIndex];
        Debug.Log(audioSource.clip);
        audioSource.Play();
    }
}
