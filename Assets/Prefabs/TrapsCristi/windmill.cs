using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmill : MonoBehaviour
{
    [SerializeField]
    float RotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = transform.rotation;
        float rotationAmmount = RotationSpeed * Time.deltaTime;

        Quaternion deltaRotaiton = Quaternion.Euler(0f, rotationAmmount, 0f);
        transform.rotation = currentRotation * deltaRotaiton;
    }
}
