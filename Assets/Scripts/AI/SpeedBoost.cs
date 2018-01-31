using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpeedBoost : MonoBehaviour
{
    public float addSpeed;
    private void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        NavMeshAgent agent = collision.collider.GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed += addSpeed;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed += addSpeed;
        }
    }
}
