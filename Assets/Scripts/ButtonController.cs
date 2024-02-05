using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velocity = 12f;
    public float jumpForce = 0.3f;
    public Vector2 inputDirection;

    private float currVel;
    private bool touchingGum;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }

        if (touchingGum)
        {
            currVel = velocity / 4;
        }
        else
        {
            currVel = velocity;
        }
    }

    private void FixedUpdate()
    {
        // Make it move!
        float movementDirection = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(movementDirection, 0f) * currVel * Time.deltaTime);

        // Make it jump!
        if (Input.GetButton("Jump") && CanJump())
            rb.velocity += new Vector2(0f, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        
    }

    private bool CanJump()
    {
        if (touchingGum)
        {
            return false;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f);

        if (hit.collider != null)
            {return (hit.collider.CompareTag("Platform"));}
        return false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gum"))
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gum"))
        {
            touchingGum = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gum"))
        {
            touchingGum = false;
        }

    }
}
