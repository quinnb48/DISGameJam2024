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
    public float jumpDelay = 0.5f;

    private float jumpTimer;
    private float currVel;
    private bool touchingGum;
    private bool endGame; //this shuts down player movement/control/input for end game sequence

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }

        if(endGame == false){
            if (touchingGum)
            {
                currVel = velocity / 4;
            }
            else
            {
                currVel = velocity;
            }
        }
        else{
            currVel = 0;
            jumpForce = 0;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            transform.rotation = Quaternion.identity;
        }
    }

    private void FixedUpdate()
    {
        if(endGame == false){
            // Make it move!
            float movementDirection = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector2(movementDirection, 0f) * currVel * Time.deltaTime);

            // Make it jump!
            jumpTimer -= Time.deltaTime;
            if (Input.GetButton("Jump") && CanJump())
            {
                rb.velocity += new Vector2(0f, jumpForce);
                jumpTimer = jumpDelay;
                //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private bool CanJump()
    {
        if (touchingGum || jumpTimer > 0)
        {
            return false;
        }

        for (float i = -0.15f; i <= 0.15f; i += 0.05f)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + i, transform.position.y), Vector2.down, 0.3f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Platform")) {
                    return true;
                }
            }
        }
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

        if(collision.gameObject.CompareTag("GoalZone")){
            endGame = true;
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
