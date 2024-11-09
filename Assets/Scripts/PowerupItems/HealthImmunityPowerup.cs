using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthImmunityPowerup : MonoBehaviour
{
    [SerializeField] private float _healthImmunityItemSpeed;
    [SerializeField] private float _powerupDuration;

    private void Update()
    {
        DoubleScoreItemMovement();
    }

    private void DoubleScoreItemMovement()
    {
        transform.position += Vector3.left * _healthImmunityItemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border")) Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            PlayerController _playerREF = collision.GetComponent<PlayerController>();

            if (_playerREF != null)
            {
                AudioManager.Instance.PlaySFX(AudioTypeList.HealthImmunityPowerup);
                _playerREF.ActivateHealthImmunity(_powerupDuration);
            }

            Destroy(gameObject);
        }
    }
}
