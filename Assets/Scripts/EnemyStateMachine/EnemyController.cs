using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float idleDuration;
    [SerializeField] private float detectionRadius;
    [SerializeField] private bool isChasing;
    [SerializeField] private bool isKingChasing;
    [SerializeField] private bool isStun;

    [SerializeField] private GameObject flag;
    [SerializeField] private IEnemyState currentState;
    private NavMeshAgent agent;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(pointA, pointB);
        Gizmos.DrawWireSphere(pointA, 1.0f);
        Gizmos.DrawWireSphere(pointB, 0.8f);
    }

    private void Start()
    {
        if (!isKingChasing)
        {
            currentState = new PatroleState(this, pointB);
            currentState.EnterState();
            isKingChasing = false;

        }
        agent = GetComponent<NavMeshAgent>();
        isChasing = false;
        isStun = false;
        SubscribeToFlag();
    }

    private void Update()
    {
        //StartCoroutine(WaitAndPrint()); 
        currentState.UpdateState();
        if (!isChasing & !isKingChasing & !isStun)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

            if (hitColliders.Length > 0)
            {
                Debug.Log("here");
                Debug.Log("ch" + isChasing + " ki" + isKingChasing + " st" + isStun);

                isChasing = true;
                TransitionToState(new ChaseState(this, hitColliders[0].gameObject));
                hitColliders[0].gameObject.GetComponent<PlayerController>().AddChasedBy(this.gameObject);
            }
        }
    }

    public void TransitionToState(IEnemyState state)
    {
        //Debug.Log(currentState + " to "+ state);
        if (!isKingChasing)
        {
            currentState?.ExitState();
            currentState = state;
            currentState.EnterState();
        }

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

    public void SetStun(bool stun)
    {
        isStun = stun;
    }

    public void SetIsKingChasing()
    {
        isKingChasing = true;
    }
    public void AttackTheKing(GameObject king)
    {
        TransitionToState(new KingChaseState(this, king));
        isKingChasing = true;
    }

    public void SubscribeToFlag()
    {
        flag = GameObject.Find("Flag");

        if (flag != null)
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
        if (flag)
        {
            FlagManager flagManager = flag.GetComponent<FlagManager>();
            if (flagManager)
                flagManager.FlagCaptured.RemoveListener(AttackTheKing);
        }
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log(currentState);
    }

    private void OnDestroy()
    {
        UnsubscribeToFlag();
        GameObject.Find("GameManager")?.GetComponent<Game>().OneDie();
    }

}
