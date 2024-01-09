using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : IPlayerState
{
    private PlayerController player;

    public IdlePlayerState(PlayerController player)
    {
        this.player = player;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, player.GetDetectionRadius(), player.GetEnemyLayer() );
            if (hitColliders.Length >0)
            {
                //Attaquer l'enemy
                player.TransitionToState(new AttackState(player, hitColliders[0].gameObject));
            }
    }

    public override void ExitState()
    {

    }

}
