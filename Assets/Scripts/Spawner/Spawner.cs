using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Details")]
    [SerializeField] private GameObject _spawnItem;

    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

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

        float randomY = Random.Range(_minY, _maxY);

        Vector3 spawnPosition = transform.position + new Vector3(0, randomY, 0);
        Instantiate(_spawnItem, spawnPosition, Quaternion.identity);
    }
}
