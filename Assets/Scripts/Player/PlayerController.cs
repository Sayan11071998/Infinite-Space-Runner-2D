using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    [SerializeField] private Rigidbody2D rb;

    private Vector2 _playerMoveDirection;

    private void Update()
    {
        float _directionYInput = Input.GetAxis("Vertical");
        _playerMoveDirection = new Vector2(0, _directionYInput).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, _playerMoveDirection.y * _playerSpeed);
    }
}
