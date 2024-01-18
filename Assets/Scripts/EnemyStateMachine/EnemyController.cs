using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
//    [SerializeField] private float walkSpeed;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float idleDuration;
    [SerializeField] private float detectionRadius;
    [SerializeField] private bool isChasing ;
    [SerializeField] private bool isKingChasing;
    [SerializeField] private GameObject flag; 
    [SerializeField] private IEnemyState currentState;
    private UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        Debug.Log("StartDeEnemy");
        currentState = new PatroleState(this, pointB);
        currentState.EnterState();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isChasing = false;
        isKingChasing = false;
        SubscribeToFlag(); 

    }

    private void Update()
    {
        currentState.UpdateState();
        if (!isChasing & !isKingChasing)
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
        //Debug.Log("Je transitionne from "+ currentState + " to " + state);
        //Debug.Log(gameObject);
        //Debug.Log("Transition"+ currentState + this.gameObject);
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
        if ((agent.velocity.magnitude == 0) & (Vector3.Distance(targetPoint, transform.position) < 1))
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

    public void isnotChassing()
    {
        isChasing = false;
    }

    public void AttackTheKing(GameObject king)
    {
        Debug.Log("Debut");
        isKingChasing = true;
        Debug.Log(new KingChaseState(this, king));
        TransitionToState(new KingChaseState(this, king));
        Debug.Log("Fin");

    }

    public void SubscribeToFlag()
    {
        flag = GameObject.Find("Flag");
        if (flag!=null)
        {
            flag.GetComponent<FlagManager>().FlagCaptured.AddListener(AttackTheKing); 

        }
        else 
        {
            Debug.LogWarning("The gameObject \"Flag\" is not found in the current scene.");
        }
    }

    public void UnsubscribeToFlag()
    {
        flag.GetComponent<FlagManager>().FlagCaptured.AddListener(AttackTheKing); 
    }

    private void OnDestroy() 
    {
        UnsubscribeToFlag();       
    }

}
