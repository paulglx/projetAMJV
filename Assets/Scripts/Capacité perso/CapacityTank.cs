using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapacityTank : Capacity
{

    [SerializeField] private float radius;

    public override bool Use(GameObject target, Vector3 point)
    {
        // Get all enemies in range
        // Push them away
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        List<GameObject> enemiesInSight = new List<GameObject>();

        Debug.Log("hitColliders: " + hitColliders.Length);

        foreach (Collider collider in hitColliders)
        {
            Debug.Log("collider: " + collider.gameObject.name);
            if (collider.gameObject.CompareTag("Enemy"))
            {
                enemiesInSight.Add(collider.gameObject);
            }
        }

        Debug.Log("enemiesInSight: " + enemiesInSight.Count);

        if (enemiesInSight.Count == 0)
        {
            return false;
        }

        foreach (GameObject enemy in enemiesInSight)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            enemy.GetComponent<NavMeshAgent>().Warp(enemy.transform.position + direction.normalized * radius);
        }

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
