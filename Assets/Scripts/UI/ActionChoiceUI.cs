using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionChoiceUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject _actionChoiceWindow;
    [SerializeField] Button _triggerDialogButton;
    [SerializeField] Button _triggerAccusationButton;

    private Dialog _currentNPCDialog;
    private Accusation _currentNPCAccusation;

    public void Init(Dialog dialog, Accusation accusation)
    {
        _currentNPCDialog = dialog;
        _currentNPCAccusation = accusation;
    }

    public void Show()
    {
        _actionChoiceWindow.SetActive(true);
        _triggerDialogButton.onClick.AddListener(_currentNPCDialog.Next);
    }

    public void Hide()
    {
        _triggerDialogButton.onClick.RemoveListener(_currentNPCDialog.Next);
        _actionChoiceWindow.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
