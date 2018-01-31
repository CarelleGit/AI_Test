using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehaviourManager : MonoBehaviour
{
    [HideInInspector]
    public Stack<Behaviour> behaviours;
    [HideInInspector]
    public NavMeshAgent agent;
    WalkTowardsBehaviout walkTowards;

    // Use this for initialization
    void Start()
    {
        walkTowards = GetComponent<WalkTowardsBehaviout>();
        agent = GetComponent<NavMeshAgent>();
        behaviours = new Stack<Behaviour>();

        behaviours.Push(walkTowards);
    }

    // Update is called once per frame
    void Update()
    {
        if (behaviours.Count > 0)
        {
            behaviours.Peek().doBehaviour(this);
            behaviours.Peek().UpdateBehaviour(this);
        }
    }
}
