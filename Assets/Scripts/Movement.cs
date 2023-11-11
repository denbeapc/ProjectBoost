using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float thrust = 1000f;
    float rotation = 100f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(rotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotate(-rotation);
        }
    }

    void Rotate(float rotationForce)
    {
        // We need to freeze rotation so that the physics system doesn't mess up
        // our manual rotation logic
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void Thrust()
    {
        rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
    }
}
