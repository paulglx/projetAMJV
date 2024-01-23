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
            enemy.TransitionToState(new StunState(enemy));
            return true;
        }
        return false;
    }
}
