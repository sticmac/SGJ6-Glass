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

    private Dialog _currentDialog;
    private IEnumerator<DialogElement> _dialogEnumerator;

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
        if (_dialogEnumerator.MoveNext())
        {
            DisplayDialogElement(_dialogEnumerator.Current);
        }
        else
        {
            _uiWindowActivator.Hide();
            _currentDialog.End();
        }
    }

    private void DisplayDialogElement(DialogElement element)
    {
        _authorText.text = element.Author.Name;
        _messageText.text = element.Message;
    }
}
