using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10f;

    private float _bulletDamageAmount;

    private void Start()
    {
        _bulletDamageAmount = 20f;
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyController>().TakeDamage();
        }

        if (collision.CompareTag("BossEnemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<FinalBoss>().TakeDamage(_bulletDamageAmount);
        }
    }
}