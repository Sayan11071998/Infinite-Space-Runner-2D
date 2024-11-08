using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    [Header("Spawner Details")]
    [SerializeField] private GameObject _spawnItem;
    [SerializeField] private Vector3 _spawnPosition;

    [SerializeField] private float _spawnInterval;
    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            Spawn();
            _nextSpawnTime = Time.time + _spawnInterval;
        }
    }

    private void Spawn()
    {
        if (GameManager.Instance._isGameOver) return;

        Instantiate(_spawnItem, _spawnPosition, Quaternion.identity);
    }
}