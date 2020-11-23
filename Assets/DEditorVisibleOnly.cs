using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DEditorVisibleOnly : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
