using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip[] music;
    public float volume;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audio.volume = volume;

        if (!_audio.isPlaying)
        {
            ChangeSong(Random.Range(0, music.Length));
        }
    }

    void ChangeSong(int Song_picked)
    {
        _audio.clip = music[Song_picked];
        _audio.Play();
    }
}
