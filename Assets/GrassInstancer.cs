using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GrassInstancer : MonoBehaviour
{
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private int count = 1000000;
    [SerializeField] private float radius = 1000;
    [SerializeField] private bool srpBatcher = true;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var radial = Random.insideUnitCircle * radius;
            var position = transform.position + new Vector3(radial.x, 0, radial.y);
            var instance = Instantiate(prefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }

    private void Update()
    {
        GraphicsSettings.useScriptableRenderPipelineBatching = srpBatcher;
    }
}