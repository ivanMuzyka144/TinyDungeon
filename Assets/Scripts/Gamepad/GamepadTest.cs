using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadTest : MonoBehaviour
{
    void Update()
    {
        Vector2 leftJoystickInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(leftJoystickInput != Vector2.zero)
        {
            Debug.Log(leftJoystickInput);
        }

       // Debug.Log(Input.GetAxisRaw("GamepadHorizonalAxis"));

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("x0");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("x2");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("x3");//
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Debug.Log("x4");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Debug.Log("x5");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Debug.Log("x6");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("x7");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            Debug.Log("x8");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            Debug.Log("x9");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button10))
        {
            Debug.Log("x10");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button11))
        {
            Debug.Log("x11");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button12))
        {
            Debug.Log("x12");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button13))
        {
            Debug.Log("x14");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button15))
        {
            Debug.Log("x15");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button16))
        {
            Debug.Log("x16");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button17))
        {
            Debug.Log("x17");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button18))
        {
            Debug.Log("x18");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button19))
        {
            Debug.Log("x19");
        }
        
    }
}
