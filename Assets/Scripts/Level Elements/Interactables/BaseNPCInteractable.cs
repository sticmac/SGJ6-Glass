using UnityEngine;
using TNRD;
using Sticmac.ObservableModels;

/// <summary>
/// Triggers an NPC dialog when interacted with
/// </summary>
public class BaseNPCInteractable : MonoBehaviour, IInteractable, ISerializationCallbackReceiver
{
    [Header("Data")]
    [InspectorName("Selected Glassie NPC Model")]
    [SerializeField] SerializableInterface<IWritableModel<GlassieNPC>> _serializedSelectedGlassieNPCModel;

    [Header("NPC Assets")]
    [SerializeField] Character _NPCCharacter;

    [Header("NPC Mechanics")]
    [SerializeField] Dialog _dialog;
    [SerializeField] Accusation _accusation;

    private IWritableModel<GlassieNPC> _selectedGlassieNPCModel;
    private GlassieNPC _thisGlassie;

    public void Start()
    {
        _thisGlassie = new GlassieNPC(_NPCCharacter, _dialog, _accusation);
    }

    public void Interact()
    {
        _selectedGlassieNPCModel.Value = _thisGlassie;
    }

    public void InteractorFarAway()
    {
    }

    public void InteractorNearby()
    {
    }

    #region Serialization
    public void OnAfterDeserialize()
    {
        _selectedGlassieNPCModel = _serializedSelectedGlassieNPCModel.Value;
    }

    public void OnBeforeSerialize()
    {
        _serializedSelectedGlassieNPCModel.Value = _selectedGlassieNPCModel;
    }
    #endregion
}
