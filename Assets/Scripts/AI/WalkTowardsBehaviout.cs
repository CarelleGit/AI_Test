using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardsBehaviout  : Behaviour
{
    GameObject target;

    public override void doBehaviour(BehaviourManager manager)
    {
        manager.agent.destination = target.transform.position;
    }
    public override bool checkBehaviour(BehaviourManager manager)
    {
        return pathComplete(manager);

        return false;
    }

    public override void UpdateBehaviour(BehaviourManager manager)
    {
        if(checkBehaviour(manager))
        {
            manager.behaviours.Pop();
        }
    }


}
