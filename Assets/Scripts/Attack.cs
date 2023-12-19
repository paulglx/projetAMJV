using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float range; // Distance at which the soldier can hit the target
    [SerializeField] private GameObject target; // The attacker will attack the target if in range. Else, it will follow it.
    [SerializeField] private float attackDelay; // Attack delay in seconds
    [SerializeField] private AttackType attackType = AttackType.CONTACT;
    [SerializeField] private GameObject projectile;

    enum AttackType
    {
        CONTACT,
        REMOTE,
        REMOTEAUTO
    }

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
        SetStoppingDistance();
    }

    void SetStoppingDistance()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();

        if (target)
            navMeshAgent.stoppingDistance = range;
        else
            navMeshAgent.stoppingDistance = 1;
    }

    void DoAttack(GameObject target)
    {
        if (attackType == AttackType.CONTACT)
            DoContactAttack(target);
        else
            DoRemoteAttack(target);
    }

    void DoContactAttack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.ApplyDamage(damage);
        }
    }

    void DoRemoteAttack(GameObject target)
    {
        GameObject newProjectile = Instantiate(projectile);
        ProjectileTargetPosition projectileAttack = newProjectile.GetComponent<ProjectileTargetPosition>();
        projectileAttack.setProjectile(transform.position, target.transform.position, damage);

    }

    public GameObject GetTarget()
    {
        return target ? target : null;
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public float GetRange()
    {
        return range;
    }
}
