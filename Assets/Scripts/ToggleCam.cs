using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ToggleCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera FirstPersonCamera;
    [SerializeField] private CinemachineVirtualCamera ThirdPersonCamera;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            ShowThirdPersonView();
        }
        if (Input.GetKey(KeyCode.F))
        {
            ShowFirstPersonView();
        }
    }

    // Call this function to disable FPS camera
    // and enable overhead camera.
    public void ShowThirdPersonView()
    {
        FirstPersonCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView()
    {
        FirstPersonCamera.enabled = true;
        ThirdPersonCamera.enabled = false;
    }

    public bool FirstPersonState()
    {
        return FirstPersonCamera.enabled;
    }

    public bool ThirdPersonState()
    {
        return ThirdPersonCamera.enabled;
    }
}