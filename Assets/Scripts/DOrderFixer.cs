using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DOrderFixer : MonoBehaviour
{
    public enum Type { Static, Dynamic }
    public Type type = Type.Dynamic;

    private float UPDATE_RATE = 0.5f;
    private int DEPTH = 100;
    private int CUSTOM_FIX = 0;

    float count;
    SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();

        if (type == Type.Static)
        {
            render.sortingOrder = (int)(-transform.position.y * DEPTH) + CUSTOM_FIX;
            Destroy(this);
        }
    }
    private void Update()
    {
        count -= Time.deltaTime;
        if (count < 0)
        {
            count = UPDATE_RATE;
            int order = (int)(-transform.position.y * DEPTH) + CUSTOM_FIX;
            render.sortingOrder = order;

            /*foreach (Transform child in transform)
            {
                SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
                if (renderer != null)
                    renderer.sortingOrder = order + 1;
            }
            */
        }
    }

    public void UpdateOrder()
    {
        render.sortingOrder = (int)(-transform.position.y * DEPTH) + CUSTOM_FIX;
    }

}
