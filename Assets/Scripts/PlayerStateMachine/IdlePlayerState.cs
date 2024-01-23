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
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, player.GetDetectionRadius(), player.GetEnemyLayer());
        if (hitColliders.Length > 0)
        {
//            Debug.Log(hitColliders[0].gameObject.transform.position);
//            Debug.Log(player.GetDetectionRadius()+ " > "+ Vector3.Distance(player.gameObject.transform.position, hitColliders[0].gameObject.transform.position));

            //Attaquer l'enemy
            if (player.GetComponent<Attack>())
                player.TransitionToState(new AttackState(player, hitColliders[0].gameObject));
        }
    }

    public override void ExitState()
    {

    }

    public override string GetState()
    {
        return "IdlePlayerState";
    }

}
