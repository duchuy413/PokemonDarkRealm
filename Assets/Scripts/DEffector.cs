using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEffector : MonoBehaviour
{
    float cameraOriginalSize;
    float range;
    float count;

    public void ShakeScreen(float duration, float magnitude)
    {
        StartCoroutine(ShakeScreenRoutine(duration, magnitude));
    }

    public IEnumerator ShakeScreenRoutine(float duration, float magnitude)
    {
        Vector3 originalPos = DGameSystem.cameraMain.transform.localPosition;

        DGameSystem.cameraMain.GetComponent<DCamera>().enabled = false;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            DGameSystem.cameraMain.transform.localPosition = new Vector3(originalPos.x +x, originalPos.y +y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        DGameSystem.cameraMain.transform.localPosition = originalPos;
        DGameSystem.cameraMain.GetComponent<DCamera>().enabled = true;
    }
}
