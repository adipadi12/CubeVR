using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform explosionEffect;
    [SerializeField] private AudioClip explosionSound;

    private Transform playerHead;
    private AudioSource audioSource;

    private void Start()
    {
        playerHead = FindObjectOfType<OVRCameraRig>().centerEyeAnchor;
        audioSource = GetComponent<AudioSource>();
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
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            ScoreManager.Instance.AddScore(0.5f);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
