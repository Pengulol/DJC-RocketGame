using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float speed = 1.0f;
    public float yOffset = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 2f) + yOffset , transform.position.z);
    }
}
