using UnityEngine;

public class DummyInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact");
    }

    public void InteractorFarAway()
    {
        Debug.Log("Player Far Away");
    }

    public void InteractorNearby()
    {
        Debug.Log("Player Nearby");
    }
}
