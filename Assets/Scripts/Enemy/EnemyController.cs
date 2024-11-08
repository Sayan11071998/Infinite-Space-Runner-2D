using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyDamageAmount;

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
}