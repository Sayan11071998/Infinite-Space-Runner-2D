using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;

    private void Update()
    {
        transform.position += Vector3.left * _enemySpeed * Time.deltaTime;
    }
}