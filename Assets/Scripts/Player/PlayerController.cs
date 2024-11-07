using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private Rigidbody2D rb;

    private Vector2 _playerMoveDirection;


    private void Update()
    {
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

        if (_playerHealth <= 0)
        {
            Debug.Log("Player is Dead");
            // Destroy(gameObject);
        }
    }
}
