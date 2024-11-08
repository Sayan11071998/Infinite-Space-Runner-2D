using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _bulletSpeed = 5f;

    [Header("Movement Properties")]
    [SerializeField] private Vector2 _roamAreaMin;
    [SerializeField] private Vector2 _roamAreaMax;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _changeDirectionInterval = 2f;

    private float _currentHealth;
    private float _fireCooldown;
    private Vector2 _moveDirection;
    private float _changeDirectionTimer;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _fireCooldown = 1 / _fireRate;
        SetRandomDirection();
    }

    private void Update()
    {
        HandleFiring();
        HandleMovement();
    }

    private void HandleFiring()
    {
        _fireCooldown -= Time.deltaTime;

        if (_fireCooldown <= 0)
        {
            FireBullet();
            _fireCooldown = 1 / _fireRate;
        }
    }

    private void HandleMovement()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);

        Vector2 position = transform.position;
        if (position.x < _roamAreaMin.x || position.x > _roamAreaMax.x || position.y < _roamAreaMin.y || position.y > _roamAreaMax.y)
            _moveDirection = -_moveDirection;

        _changeDirectionTimer -= Time.deltaTime;

        if (_changeDirectionTimer <= 0)
        {
            SetRandomDirection();
            _changeDirectionTimer = _changeDirectionInterval;
        }
    }

    private void SetRandomDirection()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        _moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public void TakeDamage(float damage)
    { 
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
        
        AudioManager.Instance.PlaySFX(AudioTypeList.EnemyHit);
    }

    private void FireBullet()
    {
        if (_bulletPrefab && _bulletSpawnPoint)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.Euler(0, 0, 180f));

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            if (rb != null)
                rb.velocity = Vector2.left * _bulletSpeed;
        }
    }

    private void Die()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.EnemyDeath);
        Destroy(gameObject);
    }
}