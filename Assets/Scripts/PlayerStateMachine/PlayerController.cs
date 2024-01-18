using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private IPlayerState currentState;
    private UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        currentState = new IdlePlayerState(this);
        currentState.EnterState();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        currentState.UpdateState();

    }

    public void TransitionToState(IPlayerState state)
    {

        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    public bool isArrived(Vector3 targetPoint)
    {
        return agent.velocity.magnitude == 0 & Vector3.Distance(targetPoint, transform.position) < 1;
    }


    public float GetDetectionRadius()
    {
        return detectionRadius;
    }


    public LayerMask GetEnemyLayer()
    {
        return enemyLayer;
    }

    public void GoTo(Vector3 point)
    {
        if (currentState.GetState()!= "KingState")
        {
            TransitionToState(new MovementState(this, point)) ;
        }
        else 
        {
            TransitionToState( new KingState(this, point));
        }

    }
}