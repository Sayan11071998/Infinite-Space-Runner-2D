using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private float _playerScore = 0f;

    [Header("Player Movement Bounds")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [Header("Required Game Objects")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameUIController _gameUIPanel;
    [SerializeField] private GameOverUIController _gameOverPanel;

    [Header("Bullet Properties")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletFireRate = 0.5f;

    private Vector2 _playerMoveDirection;
    private float nextFireTime = 0f;

    private bool _isDoubleScoreActive = false;
    private float _doubleScoreTimer = 0f;

    private bool _isHealthImmunityeActive = false;
    private float _healthImmunityTimer = 0f;

    private void Start()
    {
        _playerScore = 0f;
        _gameUIPanel.UpdateHealth(_playerHealth);
        _gameUIPanel.UpdateScore(_playerScore);
    }

    private void Update()
    {
        if (GameManager.Instance._isGameOver) return;

        float _directionXInput = Input.GetAxis("Horizontal");
        float _directionYInput = Input.GetAxis("Vertical");

        _playerMoveDirection = new Vector2(_directionXInput, _directionYInput).normalized;

        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + bulletFireRate;
        }

        if (_doubleScoreTimer > 0)
        {
            _doubleScoreTimer -= Time.deltaTime;
            if (_doubleScoreTimer <= 0)
                _isDoubleScoreActive = false;
        }

        if (_healthImmunityTimer > 0)
        {
            _healthImmunityTimer -= Time.deltaTime;
            if (_healthImmunityTimer <= 0)
                _isHealthImmunityeActive = false;
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb.velocity = new Vector2(_playerMoveDirection.x * _playerSpeed, _playerMoveDirection.y * _playerSpeed);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void TakeDamage(float _damageAmount)
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.EnemyCollisionSound);
        Camera.main.GetComponent<CameraShake>().TriggerShake(0.15f, 0.3f);

        float _actualDamageAmount = _isHealthImmunityeActive ? 0 : _damageAmount;
        _playerHealth -= _actualDamageAmount;
        _playerHealth = Mathf.Clamp(_playerHealth, 0, 100);

        _gameUIPanel.UpdateHealth(_playerHealth);

        if (_playerHealth <= 0) PlayerDeath();
    }

    public void PlayerDeath()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    public void ActivateHealthImmunity(float _duration)
    {
        _isHealthImmunityeActive = true;
        _healthImmunityTimer = _duration;
    }

    public void Heal(float _healAmount)
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.HealthPickupSound);

        _playerHealth += _healAmount;
        _playerHealth = Mathf.Clamp(_playerHealth, 0, 100);

        _gameUIPanel.UpdateHealth(_playerHealth);
    }

    public void IncreaseScore(float _ScoreValue)
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.ScorePickupSound);

        float _actualPlayerScore = _isDoubleScoreActive ? _ScoreValue * 2 : _ScoreValue;
        _playerScore += _actualPlayerScore;

        _gameUIPanel.UpdateScore(_playerScore);
    }

    public void ActivateDoubleScore(float _duration)
    {
        _isDoubleScoreActive = true;
        _doubleScoreTimer = _duration;
    }

    private void ShootBullet()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.BulletFire);
        Quaternion bulletRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(_bulletPrefab, bulletSpawnPoint.position, bulletRotation);
    }
}