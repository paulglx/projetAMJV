using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float idleDuration = 3f;
    [SerializeField] private float detectionRadius = 10f;
    private bool isChasing = false;
    private IEnemyState currentState;
    private UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        Debug.Log("EnemyController Start Je suis " + pointA);
        currentState = new PatroleState(this, pointB);
        currentState.EnterState();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        currentState.UpdateState();

        // Gérer la poursuite si la touche espace est pressée
        if (!isChasing)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
            if (hitColliders.Length > 0)
            {
                isChasing = true;
                TransitionToState(new ChaseState(this, hitColliders[0].gameObject));
            }
        }
    }

    public void TransitionToState(IEnemyState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    public bool IsChasing()
    {
        return isChasing;
    }

    public void SwitchPatrole()
    {
        Vector3 pointAephemere = pointA;
        pointA = pointB;
        pointB = pointAephemere;

    }

    public float GetidleDuration()
    {
        return idleDuration;
    }

    public bool isArrived(Vector3 targetPoint)
    {
        if (agent.velocity.magnitude == 0)
        {
            return true;
        }
        return false;
    }


    public Vector3 GetpointA()
    {
        return pointA;

    }

    public Vector3 GetpointB()
    {
        return pointB;

    }


}
