using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemSpawnController : MonoBehaviour
{
    [SerializeField] private float _ScoreItemSpeed;
    [SerializeField] private float _itemScoreValue;

    private void Update()
    {
        transform.position += Vector3.left * _ScoreItemSpeed * Time.deltaTime;
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
                _playerREF.IncreaseScore(_itemScoreValue);
                Destroy(this.gameObject);
            }
        }
    }
}
