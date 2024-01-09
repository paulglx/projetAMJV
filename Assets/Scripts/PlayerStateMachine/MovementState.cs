using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : IPlayerState
{
    private PlayerController player;
    private Vector3 target;

    public MovementState(PlayerController playerController, Vector3 point)
    {
        player = playerController;
        target = point;
    }

    public override void EnterState()
    {
        MovementManager movement = player.GetComponent<MovementManager>();
        movement.GoToPoint(target);
    }

    public override void UpdateState()
    {
        // Vérifier si l'ennemi doit passer à l'état Idle après avoir atteint sa destination 
        if (player.isArrived(target))
        {
            player.TransitionToState(new IdlePlayerState(player));
        }
    }

    public override void ExitState()
    {

    }

}
