// (c) Meta Platforms, Inc. and affiliates. Confidential and proprietary.

using UnityEngine;
using Oculus.Haptics;
using System;

public class MyClass : MonoBehaviour
{
    public HapticClip clip1;
    public HapticClip clip2;
    HapticClipPlayer _playerLeft1;
    HapticClipPlayer _playerLeft2;
    HapticClipPlayer _playerRight1;
    HapticClipPlayer _playerRight2;

    public Collider FenceCollider; // Reference to the collider component attached to the fence GameObject

    void Start()
    {
        _playerLeft1 = new HapticClipPlayer(clip1);
        _playerLeft2 = new HapticClipPlayer(clip2);
        _playerRight1 = new HapticClipPlayer(clip1);
        _playerRight2 = new HapticClipPlayer(clip2);

        _playerLeft2.priority = 1;
        _playerRight2.priority = 1;
    }

    string GetControllerName(OVRInput.Controller controller)
    {
        if (controller == OVRInput.Controller.LTouch)
        {
            return "left controller";
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            return "right controller";
        }

        return "unknown controller";
    }

    void LongVibration(OVRInput.Controller controller)
    {
        // Trigger long vibration here
        // Example:
        // Haptics.Instance.TriggerLongVibration(controller);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == FenceCollider)
        {
            LongVibration(OVRInput.Controller.RTouch);
            Debug.Log("Long vibration triggered on the controller when touching the fence.");
        }
    }

    void HandleControllerInput(OVRInput.Controller controller, HapticClipPlayer clipPlayer1, HapticClipPlayer clipPlayer2, Controller hand)
    {
        string controllerName = GetControllerName(controller);

        try
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                // For the sake of this example, we're just checking when the trigger button is pressed
                // You can add additional conditions here if needed

                // Play a haptic clip or perform other actions if desired
            }

            // Rest of the input handling remains unchanged...
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    void Update()
    {
        HandleControllerInput(OVRInput.Controller.LTouch, _playerLeft1, _playerLeft2, Controller.Left);
        HandleControllerInput(OVRInput.Controller.RTouch, _playerRight1, _playerRight2, Controller.Right);
    }

    void OnDestroy()
    {
        _playerLeft1.Dispose();
        _playerLeft2.Dispose();
        _playerRight1.Dispose();
        _playerRight2.Dispose();
    }

    void OnApplicationQuit()
    {
        Haptics.Instance.Dispose();
    }
}
