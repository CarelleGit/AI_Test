using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{

    public virtual void doBehaviour(BehaviourManager manager)
    {

    }

    public virtual bool checkBehaviour(BehaviourManager manager)
    {
        return false;
    }

    public virtual void UpdateBehaviour(BehaviourManager manager)
    {
        
    }

    public bool pathComplete(BehaviourManager manager)
    {
        if (!manager.agent.pathPending)
        {
            if (manager.agent.stoppingDistance >= manager.agent.remainingDistance)
            {
                if (!manager.agent.hasPath || manager.agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
