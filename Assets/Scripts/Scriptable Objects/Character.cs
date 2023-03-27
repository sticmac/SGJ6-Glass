using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject, INameable, IVoice, ISpeaker
{
    [Header("Identity")]
    [SerializeField] string _name;
    public string Name => _name;

    [Header("Voice")]
    [SerializeField] AudioClip _voice;
    [SerializeField] float _voiceModulationAmplitude = 0f;

    public AudioClip Voice => _voice;
    public float VoiceModulationAmplitude => _voiceModulationAmplitude;
}
