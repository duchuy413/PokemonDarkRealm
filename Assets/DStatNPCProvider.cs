using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DStatNPCProvider : MonoBehaviour
{
    public string npcSpriteSheetName;
    void Start()
    {
        DStat stat = DGameSystem.LoadStat(npcSpriteSheetName);
        if (GetComponent<DMovement>() != null)
            GetComponent<DMovement>().data = stat;
        if (GetComponent<DBattle>() != null)
            GetComponent<DBattle>().stat = stat;
        if (GetComponent<DFollow>() != null)
            GetComponent<DFollow>().data = stat;
    }
}
