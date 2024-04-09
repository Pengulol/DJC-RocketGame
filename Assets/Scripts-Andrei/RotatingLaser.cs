using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLaser : MonoBehaviour
{

    public float rotationSpeed = 30f; 
    public Vector3 rotationPivot;
    void Update()
    {
        Vector3 worldPivot = transform.TransformPoint(rotationPivot);

        transform.RotateAround(worldPivot, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
