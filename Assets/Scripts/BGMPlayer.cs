using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public void Play(AudioClip clip)
    {
        AudioManager.Instance.PlayBGM(clip);
    }
}
