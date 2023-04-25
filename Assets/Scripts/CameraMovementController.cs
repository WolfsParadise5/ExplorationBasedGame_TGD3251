using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementController : MonoBehaviour
{
    //Get details from the player object
    public Transform player;
    float rotateValue;
    public float RotationSpeed;
    //Push the camera a fixed position from the player object
    public Vector3 offset;

    void Start()
    {
        RotationSpeed = 60;
    }

    void OnLook(InputValue input)
    {
        rotateValue = input.Get<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera object's position equates to players position
        transform.position = player.position + offset;
        RotateCamera();
    }

    void RotateCamera()
    {
        transform.Rotate(Vector3.up * rotateValue * RotationSpeed * Time.deltaTime);
    }
}
