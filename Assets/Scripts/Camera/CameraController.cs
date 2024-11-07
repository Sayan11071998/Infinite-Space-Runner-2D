using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _cameraFollowSpeed;

    private void LateUpdate()
    {
        transform.position += new Vector3(_cameraFollowSpeed * Time.deltaTime, 0, 0);
    }
}