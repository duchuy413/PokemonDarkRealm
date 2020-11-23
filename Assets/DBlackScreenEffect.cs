using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBlackScreenEffect : MonoBehaviour
{
    float count;
    float TRANSISION_TIME = 2f;
    float FADE_TIME = 2f;
    public SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        count = 0;
    }

    private void Update()
    {
        count += Time.deltaTime;

        if (count < TRANSISION_TIME)
        {
            transform.localScale = new Vector3(count / TRANSISION_TIME, count / TRANSISION_TIME);
        }
        else if (count < TRANSISION_TIME + FADE_TIME)
        {
            Color color = spriteRenderer.color;
            color.a = ((TRANSISION_TIME + FADE_TIME) - count) / FADE_TIME;
            spriteRenderer.color = color;
        }
        else
            gameObject.SetActive(false);
    }
}
