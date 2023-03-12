using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject _gameOverWindow;

    public void Show() => _gameOverWindow.SetActive(true);
    public void Hide() => _gameOverWindow.SetActive(false);
}
