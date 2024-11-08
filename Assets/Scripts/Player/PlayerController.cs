using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private float _playerScore = 0f;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameUIController _gameUIPanel;
    [SerializeField] private GameOverUIController _gameOverPanel;

    private Vector2 _playerMoveDirection;

    private void Start()
    {
        _gameUIPanel.UpdateHealth(_playerHealth);
        _gameUIPanel.UpdateScore(_playerScore);
    }

    private void Update()
    {
        if (_gameOverPanel._isGameOver) return;

        float _directionYInput = Input.GetAxis("Vertical");
        _playerMoveDirection = new Vector2(0, _directionYInput).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, _playerMoveDirection.y * _playerSpeed);

        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    public void TakeDamage(float _damageAmount)
    {
        _playerHealth -= _damageAmount;
        Debug.Log("Player Health: " + _playerHealth);

        _gameUIPanel.UpdateHealth(_playerHealth);

        if (_playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        _gameOverPanel.GameOver();
        Destroy(gameObject);
    }

    public void Heal(float _healAmount)
    {
        _playerHealth += _healAmount;
        _playerHealth = Mathf.Clamp(_playerHealth, 0, 100);
        _gameUIPanel.UpdateHealth(_playerHealth);
        Debug.Log("Player Health: " + _playerHealth);
    }

    public void IncreaseScore(float _ScoreValue)
    {
        _playerScore += _ScoreValue;
        _gameUIPanel.UpdateScore(_playerScore);
        Debug.Log("Player Score: " + _playerScore);
    }
}
