using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D myRB2D;

    public float velocity = 3;
    public Vector2 inputDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = myRB2D.velocity;
        inputDirection.x = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {
        myRB2D.velocity = inputDirection.normalized * velocity;
    }
}
