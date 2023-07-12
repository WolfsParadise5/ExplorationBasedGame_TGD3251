using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovementController : MonoBehaviour
{
    //Get details from the player object
    public PlayerController player;
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
        if (!player.isPlayerTriggerMenu)
            rotateValue = input.Get<Vector2>().x;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        //Camera object's position equates to players position
        transform.position = player.position + offset;
        RotateCamera();
    }
    */


    void RotateCamera()
    {
        if (!player.isPlayerTriggerMenu)
            transform.Rotate(Vector3.up * rotateValue * RotationSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (!player.isPlayerTriggerMenu)
        {
            Vector3 targetpos = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetpos, 2.0f * Time.deltaTime);
        } 
    }
}
