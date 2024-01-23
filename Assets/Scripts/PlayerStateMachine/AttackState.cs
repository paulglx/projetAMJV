using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AttackState : IPlayerState
{

    private PlayerController player;

    private readonly GameObject enemyTarget;

    private Attack attack;

    public AttackState(PlayerController player, GameObject enemy)
    {
        this.player = player;
        enemyTarget = enemy;
    }


    public override void EnterState()
    {
        attack = player.GetComponent<Attack>();
        if (attack)
            attack.SetTarget(enemyTarget);

    }

    public override void UpdateState()
    {
        if (!enemyTarget)
        {
            player.TransitionToState(new IdlePlayerState(player));
        }
    }

    public override void ExitState()
    {
        if (attack)
            attack.SetTarget(null);
    }

    public override string GetState()
    {
        return "AttackState";
    }

}
