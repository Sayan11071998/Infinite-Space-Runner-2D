using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}