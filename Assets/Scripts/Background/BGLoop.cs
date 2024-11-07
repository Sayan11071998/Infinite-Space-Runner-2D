using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    [SerializeField] private float _backgroundSpeed;
    [SerializeField] private Renderer _bgRenderer;

    private void Update()
    {
        _bgRenderer.material.mainTextureOffset += new Vector2(_backgroundSpeed * Time.deltaTime, 0f);
    }
}
