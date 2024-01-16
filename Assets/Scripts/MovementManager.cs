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
        Debug.Log("Je suis dans le Start de " + this.gameObject);
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
        //Je ne sais pas pourquoi en faisant le State Machine ca faisait une erreur, le agent est null comme si le start n'était pas call 
        // Ma théorie c'est que ca lance le script EnemyController en premier et vu que dans enemyController on appel GoToPoint peut etre que la méthode Start n'est pas fait 

        //Théorie validé il faut en parler au prof
        
        if (agent)
        {
            Debug.Log("Il y avait un agent");
            agent.SetDestination(point);
        }
        else
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(point);
            Debug.Log("Il y avait pas d'agent dans "+ this.gameObject);
        }

    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
    }
}
