using UnityEngine;

public class ScoreItemSpawnController : MonoBehaviour
{
    [SerializeField] private float _ScoreItemSpeed;
    [SerializeField] private float _itemScoreValue;

    private void Update()
    {
        ScoreItemMovement();
    }

    private void ScoreItemMovement()
    {
        transform.position += Vector3.left * _ScoreItemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border")) Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                _playerREF.IncreaseScore(_itemScoreValue);
                Destroy(gameObject);
            }
        }
    }
}
