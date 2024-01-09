using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityDoctor : Capacity
{

    [SerializeField] private float healAmount;
    [SerializeField] private GameObject healEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Use(GameObject target = null, Vector3 point = default)
    {
        if (target == null)
        {
            return false;
        }

        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth && !target.CompareTag("Enemy"))
        {
            targetHealth.Heal(healAmount);
            Instantiate(healEffect, target.transform.position, Quaternion.identity, target.transform);
            return true;
        }
        else
        {
            return false;
        }
    }
}
