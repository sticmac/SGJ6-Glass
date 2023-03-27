using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sticmac.ObservableModels;
using TNRD;

/// <summary>
/// UI script for action choice when interacting with glassie NPC
/// </summary>
public class GlassieActionChoiceUI : MonoBehaviour, ISerializationCallbackReceiver
{
    [Header("UI System")]
    [SerializeField] UIWindowActivator _uiWindowActivator;
    [SerializeField] UIMenuNavigationSystem _uiMenuNavigationSystem;

    [Header("Model")]
    [InspectorName("Selected Glassie NPC Model")]
    [SerializeField] SerializableInterface<IReadableModel<GlassieNPC>> _serializedSelectedGlassieNPCModel;

    [Header("UI Elements")]
    [SerializeField] GameObject _actionChoiceWindow;
    [SerializeField] Button _triggerDialogButton;
    [SerializeField] Button _triggerAccusationButton;

    private IReadableModel<GlassieNPC> _selectedGlassieNPCModel;

    private ITriggerable _currentNPCDialog;
    private ITriggerable _currentNPCAccusation;

    #region Enable/Disable
    private void OnEnable() {
        _selectedGlassieNPCModel.OnValueChanged += Init;
    }

    private void OnDisable() {
        _selectedGlassieNPCModel.OnValueChanged -= Init;
    }
    #endregion

    public void Init(GlassieNPC selectedGlassieNPC)
    {
        _currentNPCDialog = selectedGlassieNPC.Dialog;
        _currentNPCAccusation = selectedGlassieNPC.Accusation;
        Show();
    }

    public void Show()
    {
        _uiWindowActivator.Show();
        _uiMenuNavigationSystem.ActivateNextFrame();
    }

    public void Hide()
    {
        _uiWindowActivator.Hide();
        _uiMenuNavigationSystem.Deactivate();
    }

    public void ShowDialog()
    {
        Hide();
        _currentNPCDialog.Trigger();
    }

    public void ShowAccusation()
    {
        Hide();
        _currentNPCAccusation.Trigger();
    }

    #region Serialization
    public void OnBeforeSerialize()
    {
        _serializedSelectedGlassieNPCModel.Value = _selectedGlassieNPCModel;
    }
    public void OnAfterDeserialize()
    {
        _selectedGlassieNPCModel = _serializedSelectedGlassieNPCModel.Value;
    }
    #endregion
}