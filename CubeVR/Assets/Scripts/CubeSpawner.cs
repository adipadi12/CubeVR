using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private OVRCameraRig cameraRig;
    [SerializeField] private Transform playerHead;
    [SerializeField] private float spawnDist = 2f;
    [SerializeField] private float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCubes), 0f, spawnInterval);
    }

    void SpawnCubes()
    {
        Vector3 headPosition = cameraRig.centerEyeAnchor.position;
        Vector3 forwardDirection = cameraRig.centerEyeAnchor.forward;

        // Spawn two cubes side-by-side
        SpawnCube(headPosition + forwardDirection * spawnDist + cameraRig.centerEyeAnchor.right * Random.Range(-2f, 0f));
        SpawnCube(headPosition + forwardDirection * spawnDist + cameraRig.centerEyeAnchor.right * Random.Range(0f, 2f));
    }

    void SpawnCube(Vector3 position)
    {
        Instantiate(cubePrefab, position, Quaternion.identity);
    }
}
