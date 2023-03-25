using UnityEngine;

/// <summary>
/// Triggers an NPC dialog when interacted with
/// </summary>
public class NPCDialogInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Dialog _dialog;

    public void Interact()
    {
        _dialog.Trigger();
    }

    public void InteractorFarAway()
    {
    }

    public void InteractorNearby()
    {
    }
}
