using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitButton;

    private void Awake()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(Quit);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
