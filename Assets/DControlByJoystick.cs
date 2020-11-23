using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DControlByJoystick : MonoBehaviour
{
    public DMovement movement;

    private void Start()
    {
        movement = GetComponent<DMovement>();
    }

    void Update()
    {

        // Joystick controller
        float x = DGameSystem.joystick.Horizontal;
        float y = DGameSystem.joystick.Vertical;

        if (x == 0 && y == 0)
        {
            movement.Stand();
            return;
        }

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0) movement.state = "go_right";
            else movement.state = "go_left";
        }
        else
        {
            if (y > 0) movement.state = "go_up";
            else movement.state = "go_down";
        }
    }
}
