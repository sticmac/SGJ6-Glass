using UnityEngine;

/// <summary>
/// Triggers an NPC dialog when interacted with
/// </summary>
public class BaseNPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Dialog _dialog;
    [SerializeField] Accusation _accusation;

    public void Interact()
    {
        _dialog.TriggerDialog();
    }

    public void InteractorFarAway()
    {
    }

    public void InteractorNearby()
    {
    }
}
