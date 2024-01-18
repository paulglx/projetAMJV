using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class StunState : IEnemyState
{
    private EnemyController enemy;
    private GameObject stunEffect;
    private GameObject stunEffectInstance;

    public StunState(EnemyController enemyController)
    {
        enemy = enemyController;
        stunEffect = Resources.Load<GameObject>("StunEffect/StunEffect");
        Assert.IsNotNull(stunEffect, "Your project is missing StunEffect.prefab located in Assets/Resources//StunEffect");
    }

    public override void EnterState()
    {
        // Add effect
        stunEffectInstance = GameObject.Instantiate(stunEffect, enemy.transform.position, Quaternion.identity, enemy.transform);

        // Stop moving
        enemy.GetComponent<NavMeshAgent>().isStopped = true;

        enemy.StartCoroutine(WaitAndSwitchState(enemy));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        // Resume moving
        enemy.GetComponent<NavMeshAgent>().isStopped = false;

        GameObject.Destroy(stunEffectInstance);
    }

    IEnumerator WaitAndSwitchState(EnemyController enemy)
    {
        yield return new WaitForSeconds(2.0f);
        enemy.TransitionToState(new IdleState(enemy));
    }
}
