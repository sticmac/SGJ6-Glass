using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// UI module for managing displayed dialogs
/// </summary>
public class DialogUI : MonoBehaviour, ISubmitHandler, IPointerClickHandler
{
    [Header("UI System")]
    [SerializeField] UIModeActivator _uiModeActivator;

    [Header("UI Elements")]
    [SerializeField] GameObject _dialogWindow;
    [SerializeField] TextMeshProUGUI _authorText;
    [SerializeField] TextMeshProUGUI _messageText;

    private Dialog _currentDialog;
    private IEnumerator<DialogElement> _dialogEnumerator;

    public void Init(Dialog dialog)
    {
        _currentDialog = dialog;
        _dialogEnumerator = dialog.GetEnumerator();
        Next();
        Show();
    }

    private void Reset()
    {
        _dialogWindow = gameObject;
    }

    private void Start() {
        enabled = false;
    }

    public void Show()
    {
        _dialogWindow.SetActive(true);
        _uiModeActivator.Activate();
        StartCoroutine(Coroutines.DelayOneFrame(() => enabled = true)); // TODO: Find a better way to avoid click conflicts between player and IPointerClickHandler
        EventSystem.current.SetSelectedGameObject(gameObject); // Select current game object so that submit works
    }

    public void Hide()
    {
        _dialogWindow.SetActive(false);
        _uiModeActivator.Deactivate();
        enabled = false;
    }

    // Display next dialog element
    private void Next()
    {
        if (_dialogEnumerator.MoveNext())
        {
            DisplayDialogElement(_dialogEnumerator.Current);
        }
        else
        {
            Hide();
            _currentDialog.EndDialog();
        }
    }

    private void DisplayDialogElement(DialogElement element)
    {
        _authorText.text = element.Author.Name;
        _messageText.text = element.Message;
    }

#region Event System
    public void OnSubmit(BaseEventData eventData) => Next();
    public void OnPointerClick(PointerEventData eventData) => Next();
#endregion
}
