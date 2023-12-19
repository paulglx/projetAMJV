using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityWizard : Capacity
{

    [SerializeField] private GameObject wall;

    public override bool Use(GameObject target, Vector3 point)
    {
        // Create a wall at the given point
        Instantiate(wall, point, Quaternion.identity);

        return true;
    }
}
