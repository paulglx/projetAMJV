using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityNinja : Capacity
{

    private MovementManager movementManager;

    //    private Attack attack; 
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        movementManager = GetComponent<MovementManager>();
    }

    public override bool Use(GameObject target, Vector3 point)
    {
        if (target)
        {
            Debug.Log("I am a Ninja and I use my capacity on " + target.name);
            DoSwap(target);

            return true;
        }
        else
        {
            Debug.Log("I am a Ninja and i can't use my capacity because I have no target");
            return false;
        }
    }


    private void DoSwap(GameObject target)
    {
        (target.transform.position, transform.position) = (transform.position, target.transform.position);
        target.GetComponent<MovementManager>().GoToPoint(target.transform.position);
        movementManager.Stop();

        EnemyController enemy = target.GetComponent<EnemyController>();
        if (enemy)
        {
            enemy.TransitionToState(new StunState(enemy));
        }
    }


}
