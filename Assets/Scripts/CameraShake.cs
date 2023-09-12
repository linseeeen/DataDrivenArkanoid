using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    private static bool shaking = false;

    [Tooltip("Change when the shake should be the most powerful.")]
    public AnimationCurve HitShake;
    [Tooltip("Change when the shake should be the most powerful.")]
    public AnimationCurve DeathShake;
    private AnimationCurve curve;

    [Tooltip("How long the shake should go on, in seconds.")]
    public float duration = 1f;

    private void OnEnable()
    {
        BrickManager.OnBrickDestroy += Hit;
        Ball.OnBallDestroy += Dead;
    }

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

    private void Hit(object sender, BrickManager.OnBrickDestroyEventArgs e)
    {
        curve = HitShake;
        shaking = true;
    }

    private void Dead(object sender, EventArgs e)
    {
        curve = DeathShake;
        shaking = true;
    }
}
