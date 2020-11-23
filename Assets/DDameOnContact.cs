using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDameOnContact : MonoBehaviour
{
    public DHitParam hit;

    public void ReceiveParam(DHitParam hitParam)
    {
        hit = hitParam;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < hit.targetTags.Count; i++)
        {
            if (collision.CompareTag(hit.targetTags[i]))
            {
                collision.gameObject.SendMessage("GetHit", hit, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
