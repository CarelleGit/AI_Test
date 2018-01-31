using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum live
{
    wonder, eat, sleep, die
}

public class Living : MonoBehaviour
{
    WanderBehaviour wonder;


    NavMeshAgent agent;

    public live myLife;
    public float maxHunger;
    public float currentHunger;
    public float starvation;//Subtracted from hunger
    public float eventChangeTimer = 0.5f;//when timer counts up to this number, the behaviour changes, default is 0.5
    float timer;
    public float currentEnergy = 10;//default is 10
    public float maxEnergy;
    public float drain = 1;// default 

    public float currentLife;//my hp
    public float maxLife;
    public float damage;


    public GameObject food;
    public GameObject bed;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wonder = GetComponent<WanderBehaviour>();

        currentHunger = maxHunger;
        currentEnergy = maxEnergy;
        currentLife = maxLife;
        timer = eventChangeTimer;
    }
    void switchStates()
    {
        if (myLife == live.wonder)
        {
            currentEnergy -= drain;
            if (currentEnergy <= 0)
            {
                myLife = live.sleep;
            }
        }
        if (myLife == live.sleep)
        {
            if (currentEnergy >= maxEnergy)
            {
                myLife = live.wonder;
            }
        }
        if (myLife == live.wonder && myLife != live.sleep)
        {
            currentHunger -= starvation;
            if (currentHunger <= 0)
            {
                myLife = live.eat;
            }
        }
        if (myLife == live.eat)
        {
            currentLife += damage / 2;
            if (currentHunger >= maxHunger)
            {
                myLife = live.wonder;
            }

        }
        if (myLife == live.sleep)
        {
            currentLife -= damage;
        }
        if (currentLife <= 0)
        {
            myLife = live.die;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= eventChangeTimer)
        {
            switch (myLife)
            {
                case live.sleep:
                    float distance = Vector3.Distance(transform.position, bed.transform.position);
                    agent.destination = bed.transform.position;
                    if (distance < 1)
                    {
                        currentEnergy += drain;
                    }
                    break;
                case live.wonder:
                    agent.destination = wonder.WanderingPoints();
                    break;
                case live.eat:
                    distance = Vector3.Distance(transform.position, food.transform.position);
                    agent.destination = food.transform.position;
                    if (distance < 1)
                    {
                        currentHunger += starvation;
                    }
                    break;
                case live.die:

                    Destroy(gameObject);
                    //gameObject.SetActive(false);

                    break;
            }
            switchStates();
            timer = 0;
        }


    }
}
