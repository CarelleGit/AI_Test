using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentPather : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public GameObject target2;
    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance == 0)
        {
            agent.destination = target2.transform.position;
        }
    }
}
