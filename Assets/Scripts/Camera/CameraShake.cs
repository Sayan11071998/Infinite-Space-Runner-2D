using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPosition;
    private bool _isShaking = false;
    private float _shakeMagnitude = 0.1f;
    private float _shakeDuration = 0.5f;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        if (_isShaking)
        {
            if (_shakeDuration > 0)
            {
                transform.position = _originalPosition + Random.insideUnitSphere * _shakeMagnitude;
                _shakeDuration -= Time.deltaTime;
            }
            else
            {
                _isShaking = false;
                transform.position = _originalPosition;
            }
        }
    }

    public void TriggerShake(float magnitude, float duration)
    {
        _shakeMagnitude = magnitude;
        _shakeDuration = duration;
        _isShaking = true;
    }
}
