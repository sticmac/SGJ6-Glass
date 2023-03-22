using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event when a new dialog element is emitted.
/// </summary>
[CreateAssetMenu(fileName = "New Dialog Event", menuName = "Event System/New Dialog Event", order = 15)]
public class NewDialogEvent : ScriptableObject
{
    private HashSet<NewDialogEventListener> _listeners = new HashSet<NewDialogEventListener>();
    
    public bool RegisterListener(NewDialogEventListener listener)
    {
        return _listeners.Add(listener);
    }

    public bool UnregisterListener(NewDialogEventListener listener)
    {
        return _listeners.Remove(listener);
    }

    public void Raise(Dialog value)
    {
        foreach (NewDialogEventListener listener in _listeners)
        {
            listener.OnEventRaised(value);
        }
    }
}