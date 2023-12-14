using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float range; // Distance at which the soldier can hit the target
    [SerializeField] private GameObject target; // The attacker will attack the target if in range. Else, it will follow it.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoAttack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth)
        {

            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= range)
                targetHealth.ApplyDamage(damage);
        }
    }
}
