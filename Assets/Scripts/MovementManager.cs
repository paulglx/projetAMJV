using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToPoint(Vector3 point)
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(point);
    }
}
