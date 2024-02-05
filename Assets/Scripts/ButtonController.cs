using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public float velocity = 3;
    public Vector2 inputDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {
        transform.position = (inputDirection * velocity).normalized;
    }
}
