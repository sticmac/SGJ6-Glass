using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens to NewDialogElementEvent events and sends the corresponding data to listeners.
/// </summary>
public class NewDialogElementEventListener : MonoBehaviour
{
    [SerializeField] NewDialogElementEvent _event;
    public NewDialogElementEvent Event
    {
        get => _event;
        set
        {
            _event?.UnregisterListener(this);
            _event = value;
            _event?.RegisterListener(this);
        }
    }

    [SerializeField] UnityEvent<DialogElement> _unityEventResponse;

    public void InvokeUnityEventResponse(DialogElement value) => _unityEventResponse.Invoke(value);

    private void OnEnable() {
        Event?.RegisterListener(this);
    }

    private void OnDisable() {
        Event?.UnregisterListener(this);
    }

    public void OnEventRaised(DialogElement value)
    {
        InvokeUnityEventResponse(value);
    }
}