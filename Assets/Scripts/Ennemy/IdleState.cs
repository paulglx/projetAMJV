using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private readonly EnemyController enemy;

    public IdleState(EnemyController enemyController)
    {
        enemy = enemyController;
    }

    public override void EnterState()
    {
        // Mettre en œuvre l'état Idle
        // Par exemple, arrêter l'ennemi, jouer une animation, etc.
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
