using System;
using UnityEngine;

public class SoundSetter : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private CustomToggle musicToggle;
    [SerializeField] private CustomToggle soundToggle;

    private AudioSource _musicSource;

    private void Start()
    {
        _musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();

        bool isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 0) == 1;
        if (!isMusicEnabled && musicToggle != null) musicToggle.Switch();
        _musicSource.mute = !isMusicEnabled;

        bool isSoundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        if (!isSoundEnabled && soundToggle != null) soundToggle.Switch();
        sfxSource.mute = !isSoundEnabled;
    }

    public void ToggleSound(Boolean value)
    {
        sfxSource.mute = !value;
        PlayerPrefs.SetInt("SoundEnabled", Convert.ToInt32(value));
    }

    public void ToggleMusic(Boolean value)
    {
        _musicSource.mute = !value;
        PlayerPrefs.SetInt("MusicEnabled", Convert.ToInt32(value));
    }
}