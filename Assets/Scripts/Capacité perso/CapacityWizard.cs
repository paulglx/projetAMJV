using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CapacityWizard : Capacity
{

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject level;

    public override bool Use(GameObject target, Vector3 point)
    {
        // If target exists, do nothing : we can't create a wall on a target
        if (target)
            return false;

        // If there is no target, create a wall
        // The wall should be offset by half its size to be centered on the point
        point += new Vector3(0, wall.transform.localScale.y / 2, 0);

        Instantiate(wall, point, Quaternion.identity, level.transform);

        FindObjectOfType<NavMeshSurface>().BuildNavMesh();

        return true;
    }
}
