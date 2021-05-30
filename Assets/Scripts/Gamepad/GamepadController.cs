using System;
using UnityEngine;

public class GamepadController : MonoBehaviour
{
    public EventHandler OnTrianglePressed;
    public EventHandler OnCirclePressed;
    public EventHandler OnCrossPressed;
    public EventHandler OnSquarePressed;

    public EventHandler OnL1Pressed;
    public EventHandler OnL2Pressed;
    public EventHandler OnR1Pressed;
    public EventHandler OnR2Pressed;

    public EventHandler OnDpadTopPressed;
    public EventHandler OnDpadRightPressed;
    public EventHandler OnDpadDownPressed;
    public EventHandler OnDpadLeftPressed;

    public EventHandler OnOptionsPressed;

    private bool dpadUpHasPressed;
    private bool dpadRightHasPressed;
    private bool dpadDownHasPressed;
    private bool dpadLeftHasPressed;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            OnSquarePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            OnCrossPressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            OnCirclePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            OnTrianglePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            OnL1Pressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            OnR1Pressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            OnL2Pressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            OnR2Pressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            OnOptionsPressed?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetAxisRaw("GamepadHorizonalAxis") > 0)
        {
            if (!dpadRightHasPressed)
            {
                OnDpadRightPressed?.Invoke(this, EventArgs.Empty);
            }
            dpadRightHasPressed = true;
        }
        else 
        {
            dpadRightHasPressed = false;
        }

        if (Input.GetAxisRaw("GamepadHorizonalAxis") < 0)
        {
            if (!dpadLeftHasPressed)
            {
                OnDpadLeftPressed?.Invoke(this, EventArgs.Empty);
            }
            dpadLeftHasPressed = true;
        }
        else
        {
            dpadLeftHasPressed = false;
        }

        if (Input.GetAxisRaw("GamepadVerticalAxis") > 0)
        {
            if (!dpadUpHasPressed)
            {
                OnDpadTopPressed?.Invoke(this, EventArgs.Empty);
            }
            dpadUpHasPressed = true;
        }
        else
        {
            dpadUpHasPressed = false;
        }

        if (Input.GetAxisRaw("GamepadVerticalAxis") < 0)
        {
            if (!dpadDownHasPressed)
            {
                OnDpadDownPressed?.Invoke(this, EventArgs.Empty);
            }
            dpadDownHasPressed = true;
        }
        else
        {
            dpadDownHasPressed = false;
        }
    }
}
