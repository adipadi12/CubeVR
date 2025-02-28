using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform playerHead;
    [SerializeField] private float spawnDist = 2f;
    [SerializeField] private float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCubes), 0f, spawnInterval);
    }

    void SpawnCubes()
    {
        for (int i = 0; i <= 2; i++)
        {
            SpawnCube(Random.Range(-3f, 3f));
        }
    }

    void SpawnCube(float xOffset)
    {
        Vector3 spawnPos = playerHead.position + playerHead.forward * spawnDist + playerHead.right * xOffset;
        Instantiate(cubePrefab, spawnPos, Quaternion.identity);
    }
}
