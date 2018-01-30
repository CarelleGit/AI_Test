using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    public Vector3 leaderOffset;
    public Transform leader;
    Rigidbody rb;

    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leaderOffset = leader.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        arrive(leaderOffset);

    }
    private void arrive(Vector3 targetPos)
    {
        Vector3 targetY = targetPos;
        targetY.y = transform.position.y;
        Vector3 targetOffset = targetPos - transform.position;
        float dist = Vector3.Distance(transform.position, targetPos);
        float rampSpeed = speed * (targetOffset.magnitude / dist);
        float clippedSpeed = Mathf.Min(rampSpeed, speed);
        Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        rb.velocity = desiredVelocity;
    }
}
