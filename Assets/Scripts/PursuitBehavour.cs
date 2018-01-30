using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehavour : MonoBehaviour
{

    Rigidbody rb;

    Vector3 desiredVelocity;
    Vector3 projectedPosision;
    public float projectedDistance;

    float dist;
    public Rigidbody targetRb;

    public float speed;
    public float burstSpeed;
    float currentSpeed;
    public float acceptableDist;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
        targetRb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position);
        if (dist > acceptableDist)
        {
            currentSpeed = speed;
            projectedPosision = target.position + (targetRb.velocity.normalized * projectedDistance);
            desiredVelocity = currentSpeed * (projectedPosision - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        else
        {
            currentSpeed = burstSpeed;
            desiredVelocity = currentSpeed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }
        Debug.DrawLine(transform.position, desiredVelocity * 10, Color.green);
        Debug.DrawLine(transform.position, projectedPosision, Color.red);
        Debug.DrawLine(transform.position, target.position, Color.blue);
       
    }
}
