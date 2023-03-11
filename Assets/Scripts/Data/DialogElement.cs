using System;
using UnityEngine;

[Serializable]
public class DialogElement
{
    [SerializeField] string message;
    [SerializeField] Character author;

    public string Message => message;
    public INameable Author => author;
}