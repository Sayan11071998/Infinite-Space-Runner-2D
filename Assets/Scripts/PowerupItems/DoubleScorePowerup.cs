using UnityEngine;

public class DoubleScorePowerup : MonoBehaviour
{
    [SerializeField] private float _doubleScoreItemSpeed;
    [SerializeField] private float _powerupDuration;

    private void Update()
    {
        DoubleScoreItemMovement();
    }

    private void DoubleScoreItemMovement()
    {
        transform.position += Vector3.left * _doubleScoreItemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border")) Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                AudioManager.Instance.PlaySFX(AudioTypeList.DoubleScorePowerup);
                _playerREF.ActivateDoubleScore(_powerupDuration);
            }

            Destroy(gameObject);
        }
    }
}
