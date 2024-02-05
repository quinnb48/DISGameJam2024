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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        // Make it move!
        float movementDirection = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(movementDirection, 0f) * velocity * Time.deltaTime);

        // Make it jump!
        if (Input.GetButton("Jump") && CanJump())
            rb.velocity += new Vector2(0f, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        
    }

    private bool CanJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f);

        if (hit.collider != null)
            {return (hit.collider.CompareTag("Platform"));}
        return false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
