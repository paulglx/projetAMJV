using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyController enemyController; 

    private readonly GameObject enemyTarget;

    public ChaseState(EnemyController enemyController, GameObject enemy)
    {
        this.enemyController = enemyController;
        enemyTarget = enemy;
    }


    public override void EnterState()
    {

        // Mettre en œuvre l'état Idle
        // Par exemple, arrêter l'ennemi, jouer une animation, etc.

        enemyController.GetComponent<Attack>().SetTarget(enemyTarget);
    }

    public override void UpdateState()
    {
        // Vérifier si l'ennemi doit passer à l'état de patrouille (WalkState)
    }

    public override void ExitState()
    {
        // Nettoyer ou effectuer des actions de transition
    }

}
