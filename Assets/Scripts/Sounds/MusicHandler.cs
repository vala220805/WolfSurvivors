using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public List<AudioClip> musicClipList;

    private void Start() 
    {
        AudioClip backgroundMusic = musicClipList[Random.Range(0, musicClipList.Count)];
        AudioSource musicSource = GetComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
