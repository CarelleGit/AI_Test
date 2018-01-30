using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpose : MonoBehaviour
{


    Rigidbody rb;

    public float speed;
    public Transform target;
    public Transform target2;
    float dist;
    Vector3 points;

    void Start()
    {
        points = Vector3.Lerp(target.position, target2.position, 0.5f);
        rb = GetComponent<Rigidbody>();
    }
    void arrive(Vector3 targetPos)
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
    void Update()
    {
        //dist = Vector3.Distance(transform.position, Vector3.Lerp(target.position, target2.position, 0.5f));
        //Vector3 targetY = points;
        //targetY.y = transform.position.y;
        //Vector3 targetOffset = points - transform.position;
        //dist = Vector3.Distance(transform.position, points);
        //float rampSpeed = speed * (targetOffset.magnitude / dist);
        //float clippedSpeed = Mathf.Min(rampSpeed, speed);
        //Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
        //rb.velocity = desiredVelocity;
        Vector3 midPoint = target.position - target2.position;
        float midPointTime = Vector3.Distance(midPoint, transform.position) / speed;
        Vector3 aPos = target.position + target.GetComponent<Rigidbody>().velocity * midPointTime;
        Vector3 bPos = target2.position + target2.GetComponent<Rigidbody>().velocity * midPointTime;

        Vector3 desiredMidPoint = (aPos + bPos) / 2;
        arrive(desiredMidPoint);
    }
}
