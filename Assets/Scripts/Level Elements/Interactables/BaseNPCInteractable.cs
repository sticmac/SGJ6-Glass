using UnityEngine;

/// <summary>
/// Triggers an NPC dialog when interacted with
/// </summary>
public class BaseNPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] NPCUIMaster _uiMaster;
    [SerializeField] Dialog _dialog;
    [SerializeField] Accusation _accusation;

    public void Interact()
    {
        switch(_uiMaster.CurrentState)
        {
            case NPCUIMaster.UIState.None:
                _uiMaster.Activate(_dialog, _accusation);
                break;
            case NPCUIMaster.UIState.Dialog:
                _dialog.Next();
                break;
        }
    }

    public void InteractorFarAway()
    {
    }

    public void InteractorNearby()
    {
    }
}
