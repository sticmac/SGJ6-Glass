using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject _dialogWindow;
    [SerializeField] TextMeshProUGUI _authorText;
    [SerializeField] TextMeshProUGUI _messageText;

    private void Reset() {
        _dialogWindow = gameObject;
    }

    public void Show() => _dialogWindow.SetActive(true);
    public void Hide() => _dialogWindow.SetActive(false);

    public void DisplayDialogElement(DialogElement element)
    {
        _authorText.text = element.Author.Name;
        _messageText.text = element.Message;
    }
}
