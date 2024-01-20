using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityChameleon : Capacity
{ 
    [SerializeField] private int playerLayer;
    [SerializeField] private int invisibleLayer; 
    [SerializeField] private float capacityTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    public override bool Use(GameObject target, Vector3 point)
    {
        if ( !(target) )
        {
            Debug.Log("I am a Chameleon and I use my capacity on " );
            specialattaque();
            StopChased();

            return true;
        }
        else
        {
            Debug.Log("I am a Chameleon and i can't use my capacity");
            return false;
        }
    }


    private void specialattaque()
    {
        this.gameObject.layer = invisibleLayer; 
        
        StartCoroutine(WaitAndSwitchLayer());
    }

    private void StopChased()
    {
        List<GameObject> enemies = this.gameObject.GetComponent<PlayerController>().GetChasedBy();
        foreach (GameObject enemy in enemies)
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.TransitionToState(new PatroleState(enemyController, enemyController.GetpointB()));
        }
    }
                


    IEnumerator WaitAndSwitchLayer()
    {
        yield return new WaitForSeconds(capacityTime);
        this.gameObject.layer = playerLayer; 
    }

}
