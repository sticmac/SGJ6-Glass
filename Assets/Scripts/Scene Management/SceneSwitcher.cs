using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] int _sceneToLoad;

    public void SwitchToScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
