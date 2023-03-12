using UnityEngine;
using Sticmac.EventSystem;

/// <summary>
/// Handles the probe accusation and whether it's correct or not
/// </summary>
public class Accusation : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] bool _isProbe;

    [Header("Events")]
    [SerializeField] GameEvent _onProbeFound;
    [SerializeField] GameEvent _onProbeNotFound;

    public void Accuse()
    {
        if (_isProbe)
        {
            _onProbeFound.Raise();
        }
        else
        {
            _onProbeNotFound.Raise();
        }
    }
}
