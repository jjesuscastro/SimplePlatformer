using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 1f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;

    int health;

    private void Start()
    {
        health = GameManager.Instance.GetHealth();
        GameManager.Instance.healthEvent.Subscribe(Shake).AddTo(this);
    }

    private void Shake(int value)
    {
        if (value >= health)
        {
            health = value;
            return;
        }

        health = value;
        originalPosition = transform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
