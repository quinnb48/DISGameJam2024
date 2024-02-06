using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private Animator myAnimator;

    public float bounceHeight = 10;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            myAnimator.SetTrigger("Bounce");
            collision.collider.attachedRigidbody.velocity += new Vector2(0, bounceHeight);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            myAnimator.ResetTrigger("Bounce");
        }
    }
}
