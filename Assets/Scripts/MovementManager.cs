using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        // Debug.Log("I am " + gameObject.name + " and my animator is " + animator.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator)
            animator.SetFloat("ForwardSpeed", agent.velocity.magnitude / 5f);
    }

    public void GoToPoint(Vector3 point)
    {
        //Je ne sais pas pourquoi en faisant le State Machine ca faisait une erreur, le agent est null comme si le start n'était pas call 
        // Ma théorie c'est que ca lance le script EnemyController en premier et vu que dans enemyController on appel GoToPoint peut etre que la méthode Start n'est pas fait 

        //Théorie validé il faut en parler au prof

        if (!agent)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Enlève les erreurs quand on tue quelqu'un
        if (!agent.isActiveAndEnabled)
        {
            return;
        }

        agent.SetDestination(point);

    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
    }
}
