using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIMenuNavigationSystem : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] GameObject _defaultSelectedObject;

    private GameObject _lastSelectedObject;

    private void Reset() {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    public void Activate()
    {
        if (_lastSelectedObject == null)
        {
            _lastSelectedObject = _defaultSelectedObject;
        }
        EventSystem.current.SetSelectedGameObject(_lastSelectedObject);
    }

    public void ActivateNextFrame()
    {
        StartCoroutine(Coroutines.DelayOneFrame(Activate));
    }

    public void Deactivate()
    {
        _lastSelectedObject = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
