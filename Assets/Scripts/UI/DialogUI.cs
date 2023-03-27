using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// UI module for managing displayed dialogs
/// </summary>
public class DialogUI : MonoBehaviour
{
    [Header("UI System")]
    [SerializeField] UIWindowActivator _uiWindowActivator;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI _authorText;
    [SerializeField] TextMeshProUGUI _messageText;

    [Header("Parameters")]
    [SerializeField, Tooltip("Speed at which the message is displayed")] float _messageDisplaySpeed = 1f;

    private Dialog _currentDialog;
    private IEnumerator<DialogElement> _dialogEnumerator;
    private bool _isWrittingMessage = false;

    public void Init(Dialog dialog)
    {
        _currentDialog = dialog;
        _dialogEnumerator = dialog.GetEnumerator();
        Next();
        _uiWindowActivator.Show();
    }

    // Display next dialog element
    public void Next()
    {
        if (_isWrittingMessage)
        {
            // orders to finish writting the currently displayed message
            _isWrittingMessage = false;
        }
        else if (_dialogEnumerator.MoveNext())
        {
            // goes to next dialog element
            DisplayDialogElement(_dialogEnumerator.Current);
        }
        else
        {
            // the dialog is finished
            _uiWindowActivator.Hide();
            _currentDialog.End();
        }
    }

    private void DisplayDialogElement(DialogElement element)
    {
        _authorText.text = element.Author.Name;
        _isWrittingMessage = true;
        StartCoroutine(DisplayDialogMessageCoroutine(element.Message));
    }

    private IEnumerator DisplayDialogMessageCoroutine(string message)
    {
        float currentMessagePosition = 0;

        while (_isWrittingMessage && currentMessagePosition < message.Length)
        {
            _messageText.text = message.Substring(0, ((int)currentMessagePosition));
            yield return null;
            currentMessagePosition += _messageDisplaySpeed * Time.deltaTime;
        }

        _messageText.text = message;
        _isWrittingMessage = false;
    }
}
