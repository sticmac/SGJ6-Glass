using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event when a new dialog element is emitted.
/// </summary>
[CreateAssetMenu(fileName = "New Dialog Element Event", menuName = "Event System/New Dialog Element Event", order = 15)]
public class NewDialogElementEvent : ScriptableObject
{
    private HashSet<NewDialogElementEventListener> _listeners = new HashSet<NewDialogElementEventListener>();
    
    public bool RegisterListener(NewDialogElementEventListener listener)
    {
        return _listeners.Add(listener);
    }

    public bool UnregisterListener(NewDialogElementEventListener listener)
    {
        return _listeners.Remove(listener);
    }

    public void Raise(DialogElement value)
    {
        foreach (NewDialogElementEventListener listener in _listeners)
        {
            listener.OnEventRaised(value);
        }
    }
}