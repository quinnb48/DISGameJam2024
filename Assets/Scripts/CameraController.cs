using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;
    public Vector2 inputDirection;
    public float rotationSpeed = 5f;
    public Vector3 offset;
    public float damping;

    private float distance;
    private Vector3 velocity;
    private Quaternion targetRotation;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = initialRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        distance = Vector3.Distance(targetPosition, transform.position);

        if (targetPosition.x < minX){
            targetPosition.x = minX;
        }
        else if(targetPosition.x > maxX){
            targetPosition.x = maxX;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping / distance);

        inputDirection.x = Input.GetAxis("Horizontal");
        targetRotation = Quaternion.Euler(0, 0, inputDirection.x * rotationSpeed) * initialRotation;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
