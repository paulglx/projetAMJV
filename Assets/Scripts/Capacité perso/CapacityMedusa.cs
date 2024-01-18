using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityMedusa : Capacity
{
    public override bool Use(GameObject target, Vector3 point = default)
    {
        EnemyController enemy = target.GetComponent<EnemyController>();
        if (enemy)
        {
            target.GetComponent<EnemyController>().TransitionToState(new StunState(target.GetComponent<EnemyController>()));
            return true;
        }
        return false;
    }
}
