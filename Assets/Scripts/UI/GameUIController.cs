using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _scoreText;

    private void Update()
    {
        if (GameManager.Instance._isGameOver)
            gameObject.SetActive(false);
    }

    public void UpdateHealth(float _healAmount)
    {
        _healthText.text = "Health: " + _healAmount.ToString("0");
    }

    public void UpdateScore(float _ScoreValue)
    {
        _scoreText.text = "Score: " + _ScoreValue.ToString("0");
    }
}
