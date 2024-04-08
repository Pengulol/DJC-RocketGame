using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 50f;
    [SerializeField]
    private bool counterClockwise = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counterClockwise)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
