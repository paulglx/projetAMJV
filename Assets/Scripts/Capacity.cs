using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    private float lastUseTime;

    public abstract bool Use(GameObject target = null, Vector3 point = default);

    void Start()
    {
        lastUseTime = Time.time;
    }

    public void TryToUse(GameObject target, Vector3 point)
    {

        Debug.Log("I am " + gameObject.name + " and i try to use my capacity at " + point);

        if (Time.time - lastUseTime >= cooldown)
        {
            bool hasUsed = Use(target, point);
            if (hasUsed)
                lastUseTime = Time.time;
        }
    }

}
