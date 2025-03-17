using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementX : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 800f;
    private float sensitivity;
    private float YRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        sensitivity = mouseSensitivity / 2;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;

        //applying y rotation
        transform.localRotation = Quaternion.Euler(0f, YRotation, 0f);

    }

    public float MouseSensitivity()
    {
        return mouseSensitivity / 2;
    }
}