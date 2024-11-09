using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float _enemyMaxHealth;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyDamageAmount;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _enemyMaxHealth;
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        transform.position += Vector3.left * _enemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border")) Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                _playerREF.TakeDamage(_enemyDamageAmount);
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float _damageAmount)
    {
        _currentHealth -= _damageAmount;

        if (_currentHealth <= 0)
            Die();

        AudioManager.Instance.PlaySFX(AudioTypeList.EnemyHit);
        Camera.main.GetComponent<CameraShake>().TriggerShake(0.15f, 0.3f);
    }

    private void Die()
    {
        PlayerController _playerREF = FindAnyObjectByType<PlayerController>();
        _playerREF.IncreaseScore(50);

        AudioManager.Instance.PlaySFX(AudioTypeList.EnemyDeath);

        Destroy(gameObject);
    }
}