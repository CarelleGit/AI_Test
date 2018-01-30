using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehaviour : MonoBehaviour
{

    Rigidbody rb;

    public float speed;
    public Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 targetY = target.position;
        targetY.y = transform.position.y;
        Vector3 targetOffset = target.position - transform.position;
        float dist = Vector3.Distance(transform.position, target.position);
        float rampSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        rb.velocity = desiredVelocity;
    }
}
