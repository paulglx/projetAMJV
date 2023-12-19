using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityWizard : Capacity
{

    public override bool Use(GameObject target)
    {
        if (target)
        {
            Debug.Log("I am a wizard and i use my capacity on " + target.name);
            return true;
        }
        else
        {
            Debug.Log("I am a wizard and i can't use my capacity because i have no target");
            return false;
        }
    }
}
