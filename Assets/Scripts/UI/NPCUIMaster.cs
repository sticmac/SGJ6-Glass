using UnityEngine;
using UnityEngine.EventSystems;
using Sticmac.EventSystem;

public class NPCUIMaster : MonoBehaviour
{
    public enum UIState
    {
        None,
        ActionChoice,
        Dialog,
        GameOver
    }

    [SerializeField] ActionChoiceUI _actionChoiceUI;
    [SerializeField] DialogUI _dialogUI;
    [SerializeField] GameOverUI _gameOverUI;
    [SerializeField] GameEvent _onEnterUIMode;
    [SerializeField] GameEvent _onExitUIMode;
    
    private UIState _currentState;
    public UIState CurrentState => _currentState;

    private void Start() {
        _currentState = UIState.None;
    }

    public void Activate(Dialog dialog, Accusation accusation)
    {
        if (_currentState == UIState.None)
        {
            _actionChoiceUI.Init(dialog, accusation);
            _actionChoiceUI.Show();
            _currentState = UIState.ActionChoice;
            _onEnterUIMode.Raise();
        }
    }

    public void StartDialog()
    {
        _currentState = UIState.Dialog;
        _actionChoiceUI.Hide();
        _dialogUI.Show();
    }

    public void ExitUIMode()
    {
        _onExitUIMode.Raise();
        _dialogUI.Hide();
        _actionChoiceUI.Hide();
        _currentState = UIState.None;
    }

    public void GameOver()
    {
        _actionChoiceUI.Hide();
        _gameOverUI.Show();
        _currentState = UIState.GameOver;
    }
}
