using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    Vector3 cForce;
    Vector3 aForce;
    Vector3 sForce;
    Rigidbody rb;
    public float speed;
    public float radius;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.insideUnitCircle * 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cTarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;

        int hoodsize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider T in hood)
        {
            var Flocker = T.GetComponent<Flocking>();
            if(Flocker != null)
            {
                hoodsize++;
                Rigidbody guyRb = T.GetComponent<Rigidbody>();

                cTarget += Flocker.transform.position;
                aDesire += guyRb.velocity;
                sSum += (transform.position - T.transform.position) / radius;

            }
        }
        cTarget /= hoodsize;
        aDesire /= hoodsize;
        sSum /= hoodsize;

        cForce = (cTarget - transform.position).normalized * speed - rb.velocity;
        aForce = aDesire.normalized * speed - rb.velocity;
        sForce = sSum.normalized * speed - rb.velocity;

        rb.AddForce((cForce + aForce + sForce).normalized * speed);
    }
   
}
