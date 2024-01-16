using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityChameleon : Capacity
{ 
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private LayerMask invisibleLayer; 

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


    IEnumerator WaitAndSwitchLayer()
    {
        yield return new WaitForSeconds(capacityTime);
        this.gameObject.layer = playerLayer; 
    }

}
