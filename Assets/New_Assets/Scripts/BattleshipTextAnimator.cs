using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BattleshipTextAnimation : MonoBehaviour
{
    TMP_Text text;
    public float letterDelay = 0.04f;
    public float pulseScale = 1.2f;
    public float shakeIntensity = 2f;
    public float shakeDuration = 0.5f;

    Vector3 originalScale;
    Vector3 originalPosition;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        if (text == null)
        {
            Debug.LogError("TMP_Text not found!");
            return;
        }

        originalScale = transform.localScale;
        originalPosition = transform.localPosition;

        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        text.ForceMeshUpdate();
        int total = text.textInfo.characterCount;

        text.maxVisibleCharacters = 0;

        for (int i = 0; i <= total; i++)
        {
            text.maxVisibleCharacters = i;
            StartCoroutine(Pulse());
            yield return new WaitForSeconds(letterDelay);
        }

        yield return StartCoroutine(Shake());
    }

    IEnumerator Pulse()
    {
        float t = 0;

        while (t < 0.1f)
        {
            t += Time.deltaTime * 10f;
            transform.localScale = originalScale * Mathf.Lerp(1f, pulseScale, t);
            yield return null;
        }

        t = 0;

        while (t < 0.1f)
        {
            t += Time.deltaTime * 10f;
            transform.localScale = originalScale * Mathf.Lerp(pulseScale, 1f, t);
            yield return null;
        }
    }

    IEnumerator Shake()
    {
        float elapsed = 0;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            Vector2 offset = Random.insideUnitCircle * shakeIntensity;
            transform.localPosition = originalPosition + new Vector3(offset.x, offset.y, 0);
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}