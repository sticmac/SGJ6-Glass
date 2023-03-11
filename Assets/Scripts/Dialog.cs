using UnityEngine;
using Sticmac.EventSystem;

/// <summary>
/// Handles the logic of a running dialog, going through the different messages it contains
/// </summary>
public class Dialog : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] DialogElement[] _dialogElements;

    [Header("Events")]
    [SerializeField] GameEvent _onDialogStarted;
    [SerializeField] GameEvent _onDialogEnded;
    [SerializeField] NewDialogElementEvent _onNewDialogElement;

    private int _currentElementIndex;
    private bool _started = false;

    public void Next()
    {
        if (_started)
        {
            NextDialogElement();
        }
        else
        {
            TriggerDialog();
        }
    }

    private void TriggerDialog()
    {
        _currentElementIndex = -1;
        _started = true;
        NextDialogElement();
    }

    private void NextDialogElement()
    {
        if (++_currentElementIndex < _dialogElements.Length)
        {
            _onDialogStarted.Raise();
            _onNewDialogElement.Raise(_dialogElements[_currentElementIndex]);
        }
        else
        {
            _onDialogEnded.Raise();
            _started = false;
        }
    }
}
