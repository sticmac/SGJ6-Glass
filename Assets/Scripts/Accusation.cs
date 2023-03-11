using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the probe accusation and whether it's correct or not
/// </summary>
public class Accusation : MonoBehaviour
{
    [SerializeField] bool _isProbe;

    public bool Accuse() => _isProbe;
}
