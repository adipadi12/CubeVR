using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Transform playerHead;

    private void Start()
    {
        playerHead = FindObjectOfType<OVRCameraRig>().centerEyeAnchor;
    }

    private void Update()
    {
        Vector3 moveDir = (playerHead.position - transform.position).normalized;
        transform.position = moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller")) 
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
