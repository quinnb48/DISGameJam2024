using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingPlatformController : MonoBehaviour
{
    public float launchSpeed = 10f;
    public float heightReach = 5f;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool peak;

    private void Start()
    {
        peak = false;
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y > startPosition.y + heightReach && !peak) { // Move Up
            peak = true;
            rb.velocity = Vector3.down;
        }
        else if (transform.position.y < startPosition.y && peak) // Stop at the start
        {
            rb.velocity = Vector3.zero;
            peak = false;
        }
        else if (transform.position.y < startPosition.y + heightReach && peak) // Move Down
        {
            rb.velocity = Vector3.down;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !peak) // Start the movement
        {
            rb.velocity = Vector3.up * launchSpeed;
        }
    }

}
