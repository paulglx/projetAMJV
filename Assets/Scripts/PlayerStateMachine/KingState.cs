using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingState : IPlayerState
{
    private PlayerController player;
    private Vector3 target; 

    public KingState(PlayerController playerController, Vector3 point )
    {
        player = playerController;
        target = point;
    }

    public override void EnterState()
    {
        MovementManager movement = player.GetComponent<MovementManager>();
        movement.GoToPoint(new Vector3(0,0,0));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {

    }

    public void GoTo(Vector3 target)
    {
        MovementManager movement = player.GetComponent<MovementManager>();
        movement.GoToPoint(target);
    }

    public override string GetState()
    {
        return "KingState";
    }

}

