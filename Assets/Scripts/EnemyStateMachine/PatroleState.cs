using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroleState : IEnemyState
{
    private EnemyController enemy;
    private Vector3 target;

    public PatroleState(EnemyController enemyContr, Vector3 pointB)
    {
        enemy = enemyContr;
        target = pointB;
    }

    public override void EnterState()
    {
        MovementManager movement = enemy.GetComponent<MovementManager>();
        movement.GoToPoint(target);
    }

    public override void UpdateState()
    {
        // Vérifier si l'ennemi doit passer à l'état Idle après avoir atteint sa destination 
        if (enemy.isArrived(target))
        {
            enemy.TransitionToState(new IdleState(enemy));
        }
    }

    public override void ExitState()
    {
        enemy.SwitchPatrole();
    }


}
