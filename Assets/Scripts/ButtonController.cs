using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D myRB2D;

    public float velocity = 5f;
    public float jumpForce = 5f;
    public Vector2 inputDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        float movementDirection = Input.GetAxis("Horizontal");
        myRB2D.AddForce(new Vector2(movementDirection, 0f) * velocity * Time.deltaTime);

        if (Input.GetButton("Jump") && CanJump())
        {
            inputDirection.y = jumpForce;
        }
    }

    private bool CanJump()
    {
        //TODO
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Platform")
            {
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
