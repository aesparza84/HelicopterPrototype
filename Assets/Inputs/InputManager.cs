using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerControls input;
    private void OnEnable()
    {

        if (input == null)
        {
            input = new PlayerControls();
        }
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
