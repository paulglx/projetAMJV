using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingChaseState : IEnemyState
{
    private EnemyController enemyController; 

    [SerializeField] private GameObject enemyTarget;

    private Attack attack; 

    public KingChaseState(EnemyController enemyController, GameObject enemy)
    {
        this.enemyController = enemyController;
        enemyTarget = enemy;
    }


    public override void EnterState()
    {
        attack = enemyController.GetComponent<Attack>();
        attack.SetTarget(enemyTarget);
        Debug.Log("Enter "+ attack.GetTarget());
    }

    public override void UpdateState()
    {
        if (!enemyTarget)
        {
            enemyController.TransitionToState(new IdleState(enemyController));
        }
        Debug.Log(attack.GetTarget());
        Debug.Log(enemyTarget);
    }

    public override void ExitState()
    {
        attack.SetTarget(null);
        enemyController.isnotChassing();
    }

}
