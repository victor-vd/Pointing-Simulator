using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementY : MonoBehaviour
{
    private MouseMovementX mouseMovementX;
    private ToggleCam toggleCam;
    private float mouseSensitivity;
    private float xRotation = 0f;
    private float minRotation;
    private float maxRotation;

    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;

        mouseMovementX = FindObjectOfType<MouseMovementX>();
        toggleCam = FindObjectOfType<ToggleCam>();
    }

    void Update()
    {
        // Ensure mouseMovementX is not null
        if (mouseMovementX != null)
        {
            mouseSensitivity = mouseMovementX.MouseSensitivity();
        }

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control rotation around x-axis (Look up and down)
        xRotation -= mouseY;

        // Ensure toggleCam is not null
        if (toggleCam != null)
        {
            // Clamp rotation based on camera state
            if (toggleCam.FirstPersonState())
            {
                minRotation = -80f;
                maxRotation = 80f;
            }
            else if (toggleCam.ThirdPersonState())
            {
                minRotation = -30f;
                maxRotation = 30f;
            }
            else
            {
                minRotation = -90f;
                maxRotation = 90f;
            }
        }

        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);

        // Applying x rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}