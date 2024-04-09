using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingDrones : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 1f;

    public Transform object1;
    public Transform object2;

    private Vector3 startPosition1;
    private Vector3 startPosition2;

    void Start()
    {
        startPosition1 = object1.position;
        startPosition2 = object2.position;
    }

    void Update()
    {
        // Calculate the ping pong movement for object 1 moving diagonally to the right
        float pingPongMovement1 = Mathf.PingPong(Time.time * speed, distance);
        Vector3 newPosition1 = startPosition1 + new Vector3(pingPongMovement1, pingPongMovement1, 0);
        object1.position = newPosition1;

        // Calculate the ping pong movement for object 2 moving diagonally to the left
        float pingPongMovement2 = Mathf.PingPong(Time.time * speed, distance);
        Vector3 newPosition2 = startPosition2 + new Vector3(-pingPongMovement2, pingPongMovement2, 0);
        object2.position = newPosition2;
    }
}
