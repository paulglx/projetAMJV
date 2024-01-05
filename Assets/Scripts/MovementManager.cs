using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator)
            animator.SetFloat("ForwardSpeed", agent.velocity.magnitude / 5f);
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
