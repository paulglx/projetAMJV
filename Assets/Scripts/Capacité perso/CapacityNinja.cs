using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityNinja : Capacity
{

    public override bool Use(GameObject target, Vector3 point)
    {
        if (target)
        {
            Debug.Log("I am a Ninja and I use my capacity on " + target.name);
            specialattaque(target);

            return true;
        }
        else
        {
            Debug.Log("I am a Ninja and i can't use my capacity because I have no target");
            return false;
        }
    }


    private void specialattaque(GameObject target)
    {
        Vector3 sauvtempo = transform.position;
        transform.position = target.transform.position ;
        target.transform.position = sauvtempo  ;

    }


}
