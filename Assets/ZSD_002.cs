using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSD_002 : DInteractableObject
{
    public override void Interact()
    {
        DGameSystem.SwitchControlToPlayer();
    }
}
