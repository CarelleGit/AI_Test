using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAdvoid : MonoBehaviour
{
    Rigidbody rb;

    public float strength;
    public float range;

    Vector3 wallDir;
    // Use this for initialization
    void Start()
    {
        wallDir = transform.forward;
        rb = GetComponent<Rigidbody>();
    }
    public void doWallAdvoince()
    {
     RaycastHit hit;
        if(Physics.Raycast(transform.position, wallDir, out hit, range))
        {
            rb.AddForce(hit.normal * strength);
        }
        else
        {
            wallDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        doWallAdvoince();
    }
}
