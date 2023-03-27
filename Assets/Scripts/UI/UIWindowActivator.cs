using UnityEngine;

/// <summary>
/// Handles the activation and deactivation logic of some piece of UI.
/// </summary>
public class UIWindowActivator : MonoBehaviour
{
    [Header("UI Activation Parameters")]
    [SerializeField] GameObject _targetUIObject;
    [SerializeField] UIModeActivator _uiModeActivator;

    private void Reset()
    {
        _targetUIObject = gameObject;
        _uiModeActivator = GetComponentInParent<UIModeActivator>();
    }

    public void Show()
    {
        _targetUIObject.SetActive(true);
        StartCoroutine(
            Coroutines.DelayOneFrame(() => _uiModeActivator.Activate())
        );
    }

    public void Hide()
    {
        _targetUIObject.SetActive(false);
        _uiModeActivator.Deactivate();
    }
}
