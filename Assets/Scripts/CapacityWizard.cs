using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityWizard : Capacity
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Use(GameObject target)
    {
        Debug.Log("I am a wizard and i use my capacity");
    }
}
