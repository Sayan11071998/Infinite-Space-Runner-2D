using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 27f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            
            if (player != null)
                player.TakeDamage(_damageAmount);
            
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Border"))
            Destroy(gameObject);
    }
}
