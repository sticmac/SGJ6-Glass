using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles the detection and interaction with Interactable objects
/// </summary>
public class PlayerInteractor : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform _player;

    private List<IInteractable> _interactablesInRange;
    private IInteractable _current;

    private void Awake() {
        _interactablesInRange = new List<IInteractable>();
    }

    /// <summary>
    /// Interact with interactables in range
    /// </summary>
    public void Interact()
    {
        if (_interactablesInRange.Count > 0)
        {
            _interactablesInRange[0].Interact();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<IInteractable>(out _current))
        {
            _current.InteractorNearby();
            _interactablesInRange.Add(_current);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<IInteractable>(out _current))
        {
            _current.InteractorFarAway();
            _interactablesInRange.Remove(_current);
        }
    }
}
