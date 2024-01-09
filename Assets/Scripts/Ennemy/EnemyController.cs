using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    //public float walkSpeed = 3f;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;

    private IEnemyState currentState;
    [SerializeField] private float idleDuration = 3f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float detectionRadius = 10f; 
    private bool isChasing = false;

    private void Start()
    {
        Debug.Log("Je suis " + pointB);
        currentState = new PatroleState(this, pointA, pointB);
        currentState.EnterState();
//        TransitionToState(new PatroleState(this, pointA, pointB));
    }

    private void Update()
    {
        currentState.UpdateState();
        
        // Gérer la poursuite si la touche espace est pressée
        if (!isChasing)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

            if (hitColliders.Length >0)
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
        pointA= pointB;
        pointB= pointAephemere;

    }

    public float GetidleDuration()
    {

        return idleDuration;
    }

    public bool isArrived(Vector3 targetPoint)
    {
        if (transform.position == targetPoint )
        {
            return true ;
        }
        return false;
    }


/**
    private void private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);      


    }

**/


}
