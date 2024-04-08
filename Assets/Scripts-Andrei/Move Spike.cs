using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpike : MonoBehaviour
{
    public Transform endPosition;
    public float speed = 1.0f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Quaternion endRotation;

    private bool movingToEnd = true;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        endRotation = endPosition.rotation;
        StartCoroutine(SlideObject());
    }

    IEnumerator SlideObject()
    {
        while (true)
        {
            float journeyLength = Vector3.Distance(startPosition, endPosition.position);
            float startTime = Time.time;
            float fracJourney = 0f;

            while (fracJourney < 1)
            {
                float distCovered = (Time.time - startTime) * speed;
                fracJourney = distCovered / journeyLength;
                if (movingToEnd)
                {
                    transform.position = Vector3.Lerp(startPosition, endPosition.position, fracJourney);
                    transform.rotation = Quaternion.Slerp(startRotation, endRotation, fracJourney);
                }
                else
                {
                    transform.position = Vector3.Lerp(endPosition.position, startPosition, fracJourney);
                    transform.rotation = Quaternion.Slerp(endRotation, startRotation, fracJourney);
                }
                yield return null;
            }

            movingToEnd = !movingToEnd;
            yield return new WaitForSeconds(1.0f);
        }
    }
}