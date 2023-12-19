using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityWizard : Capacity
{

    [SerializeField] private GameObject wall;

    public override bool Use(GameObject target, Vector3 point)
    {
        // If target exists, do nothing : we can't create a wall on a target
        if (target)
            return false;

        Instantiate(wall, point, Quaternion.identity);
        return true;
    }
}
