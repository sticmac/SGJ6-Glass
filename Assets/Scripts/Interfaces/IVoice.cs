using UnityEngine;

public interface IVoice
{
    public AudioClip Voice { get; }
    public float VoiceModulationAmplitude { get; }
}
