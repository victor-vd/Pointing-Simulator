using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementX : MonoBehaviour
{

    float mouseSensitivity = MouseMovementY.mouseSensitivity;

    float xRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applying x rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}