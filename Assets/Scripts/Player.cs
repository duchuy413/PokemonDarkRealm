using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public DStat stat;

    Joystick joystick;
    DMovement playerMovement;
    Rigidbody2D rigid;
    
    private void Start()
    {
        playerMovement = GetComponent<DMovement>();
        rigid = GetComponent<Rigidbody2D>();
        
        if (isActiveAndEnabled && isLocalPlayer) {
            GameObject joystickObj = GameObject.FindGameObjectWithTag("Joystick");
            joystick = joystickObj.GetComponent<Joystick>();
            transform.position = DGameSystem.mapGenerator.PLAYER_START_PÓSITION;
            DGameSystem.cameraMain.GetComponent<DCamera>().target = this.gameObject;
            DGameSystem.RegistPlayer(this.gameObject);
        }
    }

    //void Update()
    //{
    //    if (!isLocalPlayer) return;

    //    // Joystick controller
    //    float x = joystick.Horizontal;
    //    float y = joystick.Vertical;

    //    if (x == 0 && y == 0)
    //    {
    //        playerMovement.Stand();
    //        return;
    //    }

    //    if (Mathf.Abs(x) > Mathf.Abs(y))
    //    {
    //        if (x > 0) playerMovement.state = "go_right";
    //        else playerMovement.state = "go_left";
    //    }
    //    else
    //    {
    //        if (y > 0) playerMovement.state = "go_up";
    //        else playerMovement.state = "go_down";
    //    }
    //}
}
