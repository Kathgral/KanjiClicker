using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    public AudioClip[] soundtrack;
    private AudioSource audioSource;
    private List<AudioClip> remainingSongs;
    
    void Awake(){
        audioSource = GetComponent<AudioSource>();
        ResetSongList();
    }

    void Update()
    {
        if (!audioSource.isPlaying){
            PlayRandomSong();
        }
    }

    void ResetSongList()
    {
        remainingSongs = new List<AudioClip>(soundtrack);
    }

    void PlayRandomSong()
    {
        if (remainingSongs.Count == 0){
            ResetSongList();
        }

        int randomIndex = Random.Range(0, remainingSongs.Count);
        audioSource.clip = remainingSongs[randomIndex];
        Debug.Log(audioSource.clip);
        audioSource.Play();
        remainingSongs.RemoveAt(randomIndex);
    }

    public void NextSongButton()
    {
        PlayRandomSong();
    }
}
