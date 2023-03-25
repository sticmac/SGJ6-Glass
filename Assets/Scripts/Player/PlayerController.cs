using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player controls and redirects them to proper mechanic scripts.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] PlayerInput _playerInput;

    [Header("Outputs")]
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerInteractor _playerInteractor;

    private void OnEnable()
    {
        // Subscribe to Move input
        _playerInput.actions.FindAction("Move").performed += Move;
        _playerInput.actions.FindAction("Move").canceled += Move;

        // Subscribe to Interact input
        _playerInput.actions.FindAction("Interact").performed += Interact;
    }

    private void OnDisable() {
        _playerInput.actions.FindAction("Move").performed -= Move;
        _playerInput.actions.FindAction("Move").canceled -= Move;
        _playerInput.actions.FindAction("Interact").performed -= Interact;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        _playerMovement.Move(input);
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        _playerInteractor.Interact();
    }
}
