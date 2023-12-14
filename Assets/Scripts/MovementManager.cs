using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        Attack attack = GetComponent<Attack>();
        if (attack)
        {
            GetComponent<NavMeshAgent>().stoppingDistance = attack.GetRange();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
    }
}
