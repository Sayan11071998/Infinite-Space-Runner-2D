using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    private static GameOverUIController _instance;
    public static GameOverUIController Instance { get { return _instance; } }

    [SerializeField] GameObject _gameOverPanel;

    public bool _isGameOver = false;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}