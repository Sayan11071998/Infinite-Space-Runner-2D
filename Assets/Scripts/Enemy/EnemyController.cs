using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyDamageAmount;

    private void Update()
    {
        transform.position += Vector3.left * _enemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();
            if (_playerREF != null)
            {
                _playerREF.TakeDamage(_enemyDamageAmount);
                Destroy(this.gameObject);
            }
        }
    }
}