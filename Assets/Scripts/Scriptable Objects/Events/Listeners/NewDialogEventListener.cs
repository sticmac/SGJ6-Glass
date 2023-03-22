using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens to NewDialogEvent events and sends the corresponding data to listeners.
/// </summary>
public class NewDialogEventListener : MonoBehaviour
{
    [SerializeField] NewDialogEvent _event;
    public NewDialogEvent Event
    {
        get => _event;
        set
        {
            _event?.UnregisterListener(this);
            _event = value;
            _event?.RegisterListener(this);
        }
    }

    [SerializeField] UnityEvent<Dialog> _unityEventResponse;

    public void InvokeUnityEventResponse(Dialog value) => _unityEventResponse.Invoke(value);

    private void OnEnable() {
        Event?.RegisterListener(this);
    }

    private void OnDisable() {
        Event?.UnregisterListener(this);
    }

    public void OnEventRaised(Dialog value)
    {
        InvokeUnityEventResponse(value);
    }
}