using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _spawnItem;

    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;
    
    [SerializeField] private float _timeElasped;
    private float spawnTime;

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + _timeElasped;
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);

        Instantiate(_spawnItem, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
