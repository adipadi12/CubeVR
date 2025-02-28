using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform explosionEffect;
    private Transform playerHead;

    private void Start()
    {
        playerHead = FindObjectOfType<OVRCameraRig>().centerEyeAnchor;
    }

    private void Update()
    {
        // Move toward player's head
        transform.position = Vector3.MoveTowards(transform.position, playerHead.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller")) 
        {
            ScoreManager.Instance.AddScore(0.5f);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
