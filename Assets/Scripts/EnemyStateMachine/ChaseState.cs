using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyController enemyController;

    private readonly GameObject enemyTarget;

    private Attack attack;

    public ChaseState(EnemyController enemyController, GameObject enemy)
    {
        this.enemyController = enemyController;
        enemyTarget = enemy;
    }


    public override void EnterState()
    {
        attack = enemyController.GetComponent<Attack>();
        attack.SetTarget(enemyTarget);
    }

    public override void UpdateState()
    {
        if (!enemyTarget)
        {
            enemyController.TransitionToState(new IdleState(enemyController));
        }
    }

    public override void ExitState()
    {
        attack.SetTarget(null);
        enemyController.isnotChassing();
    }

}
