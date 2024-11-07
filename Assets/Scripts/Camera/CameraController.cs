using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _playerREF;
    [SerializeField] private float _cameraFollowSpeed;
    [SerializeField] private Vector3 offSet;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(_playerREF.position.x + offSet.x, _playerREF.position.y + offSet.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _cameraFollowSpeed * Time.deltaTime);
    }
}