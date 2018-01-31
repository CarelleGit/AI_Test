using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBehaviour : MonoBehaviour
{
    Rigidbody targetRb;

    public Transform target;
    Rigidbody rb;
    public Rigidbody PursuerRb;


    Vector3 desiredVelocity;

    float dist;

    public float speed;
    public float burstSpeed;
    float currentSpeed;

    public float acceptable;
    public Transform Pursuer;
    // Use this for initialization
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
        PursuerRb = Pursuer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, Pursuer.position);
        if(dist < acceptable)
        {
            currentSpeed = burstSpeed;
            desiredVelocity = -currentSpeed * (Pursuer.position - transform.position).normalized;

            rb.AddForce(desiredVelocity - rb.velocity,ForceMode.Impulse);
        }
        else
        {
            currentSpeed = speed;
            desiredVelocity = currentSpeed * (target.position - transform.position).normalized;

            rb.AddForce(desiredVelocity - rb.velocity);
        }
        
    }
}
