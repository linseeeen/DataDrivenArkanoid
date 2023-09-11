using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static bool shaking = false;

    public static bool Shaking
    {
        get
        {
            return shaking;
        }
        set
        {
            shaking = value;
        }
    }

    [Tooltip("Change when the shake should be the most powerful.")]
    public AnimationCurve curve;

    [Tooltip("How long the shake should go on, in seconds.")]
    public float duration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (shaking) StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }

        shaking = false;
        transform.position = startPosition;
    }
}
