using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles the logic of a running dialog, going through the different messages it contains
/// </summary>
public class Dialog : MonoBehaviour, IEnumerable<DialogElement>, ITriggerable, IEndable
{
    [Header("Data")]
    [SerializeField] DialogElement[] _dialogElements;

    [Header("Events")]
    [SerializeField] NewDialogEvent _onNewDialogTriggered;
    [SerializeField] UnityEvent _onDialogEnded;

    public IEnumerator<DialogElement> GetEnumerator()
    {
        foreach (DialogElement de in _dialogElements)
        {
            yield return de;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Trigger()
    {
        _onNewDialogTriggered.Raise(this);
    }

    public void End()
    {
        _onDialogEnded.Invoke();
    }
}
