using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _mainMenuButton;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);

        _restartGameButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void GameOver()
    {
        if (_gameOverPanel != null)
            _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameManager.Instance._isGameOver = false;
        AudioManager.Instance.PlaySFX(AudioTypeList.GameOverRestartButtonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.GameOverMenuButtonSound);
        SceneManager.LoadScene(0);
    }
}