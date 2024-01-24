using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    [SerializeField] private AttackType attackType = AttackType.CONTACT;
    [SerializeField] private AudioClip soundEffect;
    [SerializeField] private float attackDelay; // Attack delay in seconds
    [SerializeField] private float damage;
    [SerializeField] private float range; // Distance at which the soldier can hit the target
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target; // The attacker will attack the target if in range. Else, it will follow it.

    private AudioSource audioSource;
    private NavMeshAgent navMeshAgent;
    private MovementManager movementManager;
    private bool canAttack;

    enum AttackType
    {
        CONTACT,
        REMOTE,
        REMOTEAUTO,
        DOGS
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
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= range & canAttack)
                {
                    DoAttack(target);
                    canAttack = false;
                    StartCoroutine(WaitForAnotherAttack());
                }
                else
                {
                    movementManager.GoToPoint(target.transform.position);
                    yield return null;
                }
            }
        }
    }

    IEnumerator WaitForAnotherAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetOrAddComponent<AudioSource>();
        if (!target)
        {
            target = null;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        movementManager = GetComponent<MovementManager>();
        canAttack = true;
        StartCoroutine(AttackLoop());

    }

    // Update is called once per frame
    void Update()
    {
        SetStoppingDistance();
    }

    void SetStoppingDistance()
    {
        if (target)
            navMeshAgent.stoppingDistance = range;
        else
            navMeshAgent.stoppingDistance = 1;
    }

    void PlayAttackSound()
    {
        // On met un pitch aléatoire pour éviter que ce soit trop répétitif
        float pitch = Random.Range(0.9f, 1.1f);
        audioSource.pitch = pitch;

        audioSource.PlayOneShot(soundEffect);
    }

    void DoAttack(GameObject target)
    {

        PlayAttackSound();

        if (attackType == AttackType.CONTACT)
            DoContactAttack(target);
        else if (attackType == AttackType.REMOTE)
            DoRemoteAttack(target);
        else if (attackType == AttackType.REMOTEAUTO)
            DoRemoteAutoAttack(target);
        else if (attackType == AttackType.DOGS)
            DoDogsAttack(target);
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
        projectileAttack.SetProjectile(transform.position, target.transform.position, damage);

    }

    void DoRemoteAutoAttack(GameObject target)
    {
        GameObject newProjectile = Instantiate(projectile);
        ProjectileTargetEnnemy projectileAttack = newProjectile.GetComponent<ProjectileTargetEnnemy>();
        projectileAttack.SetProjectile(transform.position, target, damage);
    }

    void DoDogsAttack(GameObject target)
    {
        CapacityDogTrainer capacityDogTrainer = GetComponent<CapacityDogTrainer>();
        capacityDogTrainer.SetDogsTarget(target);
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public void SetTarget(GameObject newTarget)
    {
        //Debug.Log(gameObject + "  " + target + " Set " + newTarget);
        target = newTarget;
        //Debug.Log("set2 " + target);
    }

    public float GetRange()
    {
        return range;
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
