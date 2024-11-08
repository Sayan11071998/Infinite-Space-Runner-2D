using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemSpawnController : MonoBehaviour
{
    [SerializeField] private float _HealthItemSpeed;
    [SerializeField] private float _itemHealValue;

    private void Update()
    {
        transform.position += Vector3.left * _HealthItemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                _playerREF.Heal(_itemHealValue);
                Destroy(this.gameObject);
            }
        }
    }
}