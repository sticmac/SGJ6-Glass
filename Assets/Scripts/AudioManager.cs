using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }
    #endregion

    [Header("Audio Players")]
    [SerializeField] AudioSource _backgroundMusic;
    [SerializeField] AudioSource _backgroundSoundEffect;
    [SerializeField] AudioSource _soundEffect;

    public void PlayBGM(AudioClip music) {
        if (_backgroundMusic.clip != music) {
            _backgroundMusic.clip = music;
            _backgroundMusic.Play();
        }
    }

    public void StopBGM() {
        _backgroundMusic.Stop();
        _backgroundMusic.clip = null;
    }

    public void PlayBGS(AudioClip soundEffect, float pitch = 0) {
        if (_backgroundSoundEffect.clip != soundEffect) {
            _backgroundSoundEffect.clip = soundEffect;
            _backgroundSoundEffect.pitch = pitch + 1;
            _backgroundSoundEffect.Play();
        }
    }

    public void StopBGS() {
        _backgroundSoundEffect.Stop();
        _backgroundSoundEffect.clip = null;
    }

    public void PlaySoundEffect(AudioClip soundEffect, float pitch = 0, float volume = 1) {
        _soundEffect.clip = soundEffect;
        _soundEffect.pitch = pitch + 1;
        _soundEffect.volume = volume;
        _soundEffect.Play();
    }
}
