using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroleState : IEnemyState
{
    private readonly EnemyController enemy;
    private readonly Vector3 targetA;
    private Vector3 targetB;

    public PatroleState(EnemyController enemyContr, Vector3 pointA, Vector3 pointB)
    {
        enemy = enemyContr;
        targetA = pointA;
        targetB = pointB;
    }

    public override void EnterState()
    {
        // Mettre en œuvre l'état de marche (patrouille)
        // Par exemple, déplacer l'ennemi vers le point A
        Debug.Log(targetB);
 //       Debug.Log(enemy.GetComponent<MovementManager>());
        MovementManager movement = enemy.GetComponent<MovementManager>();
        movement.GoToPoint(targetB);

    }

    public override void UpdateState()
    {
        // Vérifier si l'ennemi doit passer à l'état Idle après avoir atteint sa destination (point B)
        if (enemy.isArrived(targetB))
        {
            enemy.TransitionToState(new IdleState(enemy));
        }

    }

    public override void ExitState()
    {
        // Nettoyer ou effectuer des actions de transition
        enemy.SwitchPatrole();
    }


}
