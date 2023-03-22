using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Deactivates Player controls when UI is activated
/// </summary>
public class UIModeActivator : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;

    public bool Activated { get; private set; }

    private void Reset() {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    public void Activate()
    {
        Activated = true;
        _playerInput.SwitchCurrentActionMap("UI"); // only to disable Player controls
    }

    public void Deactivate()
    {
        Activated = false;
        _playerInput.SwitchCurrentActionMap("Player"); // enable Player controls
    }
}
