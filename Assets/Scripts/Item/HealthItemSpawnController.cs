using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemSpawnController : MonoBehaviour
{
    [SerializeField] private float _HealthItemSpeed;
    [SerializeField] private float _itemHealValue;

    private void Update()
    {
        HealthItemMovement();
    }

    private void HealthItemMovement()
    {
        transform.position += Vector3.left * _HealthItemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border")) Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                _playerREF.Heal(_itemHealValue);
                Destroy(gameObject);
            }
        }
    }
}