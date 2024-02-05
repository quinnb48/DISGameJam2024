using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX = 0;
    public float maxX = 40;
    public float minY = 0;
    public float maxY = 10;
    public Vector2 inputDirection;
    public float rotationSpeed = 5f;

    private Quaternion targetRotation;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (player.position.x > minX && player.position.x < maxX)
        {
            x = player.position.x;
        }
        if (player.position.y > minY && player.position.y < maxY)
        {
            y = player.position.y;
        }
        transform.position = new Vector3 (x, y, -10);

        inputDirection.x = Input.GetAxis("Horizontal");
        targetRotation = Quaternion.Euler(0, 0, inputDirection.x * rotationSpeed) * initialRotation;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }
}
