using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    private float lastUseTime;

    private Attack attack;

    public abstract bool Use(GameObject target = null);

    void Start()
    {
        attack = GetComponent<Attack>();
        lastUseTime = Time.time;
    }

    public void TryToUse()
    {

        Debug.Log("I am " + gameObject.name + " and i try to use my capacity");

        if (Time.time - lastUseTime >= cooldown)
        {
            GameObject target = attack.GetTarget();

            bool hasUsed = Use(target);
            if (hasUsed)
                lastUseTime = Time.time;
        }
    }

}
