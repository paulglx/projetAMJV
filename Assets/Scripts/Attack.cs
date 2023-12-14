using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float range; // Distance at which the soldier can hit the target
    [SerializeField] private GameObject target; // The attacker will attack the target if in range. Else, it will follow it.
    [SerializeField] private float attackDelay; // Attack delay in seconds


    IEnumerator AttackLoop()
    {
        while (true)
        {
            if (!target)
            {
                yield return null;
            }

            else
            {
                MovementManager movementManager = GetComponent<MovementManager>();

                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= range)
                {
                    DoAttack(target);
                    yield return new WaitForSeconds(attackDelay);
                }
                else
                {
                    movementManager.GoToPoint(target.transform.position);
                    yield return null;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        StartCoroutine(AttackLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void DoAttack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.ApplyDamage(damage);
        }
    }

    public float GetRange()
    {
        return range;
    }
}
