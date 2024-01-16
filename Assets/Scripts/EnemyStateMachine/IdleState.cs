using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private EnemyController enemy;

    public IdleState(EnemyController enemyController)
    {
        enemy = enemyController;
    }

    public override void EnterState()
    {
        enemy.StartCoroutine(WaitAndSwitchState(enemy));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {

    }

    IEnumerator WaitAndSwitchState(EnemyController enemy)
    {
        yield return new WaitForSeconds(enemy.GetidleDuration());
        enemy.TransitionToState(new PatroleState(enemy, enemy.GetpointB()));
    }
}
