using UnityEngine;
using Oculus.Haptics;
using System;

public class Haptics1 : MonoBehaviour
{
    public HapticClip clip1;
    public HapticClip clip2;
    HapticClipPlayer _playerLeft1;
    HapticClipPlayer _playerLeft2;
    HapticClipPlayer _playerRight1;
    HapticClipPlayer _playerRight2;

    public Collider FenceCollider;

    protected virtual void Start()
    {
        _playerLeft1 = new HapticClipPlayer(clip1);
        _playerLeft2 = new HapticClipPlayer(clip2);
        _playerRight1 = new HapticClipPlayer(clip1);
        _playerRight2 = new HapticClipPlayer(clip2);

        _playerLeft2.priority = 1;
        _playerRight2.priority = 1;
    }

    String GetControllerName(OVRInput.Controller controller)
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

    public void PlayHapticsOnGrab(OVRInput.Controller controller, HapticClipPlayer clipPlayer, Controller hand)
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            clipPlayer.Play(hand);
            Debug.Log("Should feel vibration when grabbing with " + GetControllerName(controller) + ".");
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            clipPlayer.Stop();
            Debug.Log("Vibration when grabbing with " + GetControllerName(controller) + " should stop.");
        }
    }

    Controller GetController(OVRInput.Controller ovrController)
    {
        if (ovrController == OVRInput.Controller.LTouch)
        {
            return Controller.Left;
        }
        else if (ovrController == OVRInput.Controller.RTouch)
        {
            return Controller.Right;
        }

        throw new ArgumentException("Unknown controller type: " + ovrController);
    }

    void HandleControllerInput(OVRInput.Controller controller, HapticClipPlayer clipPlayer1, HapticClipPlayer clipPlayer2, Controller hand)
    {
        string controllerName = GetControllerName(controller);

        try
        {
            /*if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                clipPlayer1.Play(hand);
                Debug.Log("Should feel vibration from clipPlayer1 on " + controllerName + ".");
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
            {
                clipPlayer2.Play(hand);
                Debug.Log("Should feel vibration from clipPlayer2 on " + controllerName + ".");
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                clipPlayer1.Stop();
                Debug.Log("Vibration from clipPlayer1 on " + controllerName + " should stop.");
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
            {
                clipPlayer2.Stop();
                Debug.Log("Vibration from clipPlayer2 on " + controllerName + " should stop.");
            }

            if (OVRInput.GetDown(OVRInput.Button.Two, controller))
            {
                clipPlayer1.isLooping = !clipPlayer1.isLooping;
                Debug.Log(String.Format("Looping should be {0} on " + controllerName + ".", clipPlayer1.isLooping));
            }*/

            if (controller == OVRInput.Controller.LTouch)
            {
                clipPlayer1.amplitude = Mathf.Clamp(1.0f + OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y, 0.0f, 1.0f);
                clipPlayer1.frequencyShift = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;
            }
            else if (controller == OVRInput.Controller.RTouch)
            {
                clipPlayer1.amplitude = Mathf.Clamp(1.0f + OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y, 0.0f, 1.0f);
                clipPlayer1.frequencyShift = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
            }

            // Call the new function to play haptics on grab
            // PlayHapticsOnGrab(controller, clipPlayer2);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    protected virtual void Update()
    {
        //HandleControllerInput(OVRInput.Controller.LTouch, _playerLeft1, _playerLeft2, Controller.Left);
        //HandleControllerInput(OVRInput.Controller.RTouch, _playerRight1, _playerRight2, Controller.Right);
    }

    public void callHap()
    {
        PlayHapticsOnGrab(OVRInput.Controller.LTouch, _playerLeft2, Controller.Left);
        PlayHapticsOnGrab(OVRInput.Controller.RTouch, _playerLeft1, Controller.Right);
    }

    protected virtual void OnDestroy()
    {
        _playerLeft1.Dispose();
        _playerLeft2.Dispose();
        _playerRight1.Dispose();
        _playerRight2.Dispose();
    }

    protected virtual void OnApplicationQuit()
    {
        Haptics.Instance.Dispose();
    }
}