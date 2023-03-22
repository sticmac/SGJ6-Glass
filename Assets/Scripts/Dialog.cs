using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// Handles the logic of a running dialog, going through the different messages it contains
/// </summary>
public class Dialog : MonoBehaviour, IEnumerable<DialogElement>
{
    [Header("Data")]
    [SerializeField] DialogElement[] _dialogElements;

    [Header("Events")]
    [SerializeField] NewDialogEvent _onNewDialogTriggered;

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

    public void TriggerDialog()
    {
        _onNewDialogTriggered.Raise(this);
    }
}
