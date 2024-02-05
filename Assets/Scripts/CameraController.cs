using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetX;
    public float offsetY;
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
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
        pos.y = player.position.y + offsetY;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        targetRotation = Quaternion.Euler(0, 0, inputDirection.x * rotationSpeed) * initialRotation;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
