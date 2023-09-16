using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool onMouseDown = false;
    public static bool onMouseHold = false;
    public static bool onMouseUp = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDown = true;
            onMouseHold = false;
            onMouseUp = false;
        }
        else if (Input.GetMouseButton(0))
        {
            onMouseDown = false;
            onMouseHold = true;
            onMouseUp = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onMouseDown = false;
            onMouseHold = false;
            onMouseUp = true;
        }



    }
}
