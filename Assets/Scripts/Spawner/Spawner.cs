using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _spawnItem;

    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;

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
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0);
        Instantiate(_spawnItem, spawnPosition, Quaternion.identity);
    }
}
