using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    [SerializeField] private float range;

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
            if (isInRange(target, point))
            {
                bool hasUsed = Use(target, point);
                if (hasUsed)
                    lastUseTime = Time.time;
            }

        }
        else
        {
            Debug.Log("I can't use yet my capacity ");
        }
    }

    public bool isInRange(GameObject target, Vector3 point)
    {

        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance <= range)
            {
                return true;
            }
        }

        if (point != null)
        {
            float distance = Vector3.Distance(point, transform.position);
            if (distance <= range)
            {
                return true;
            }
        }

        return false;
    }

}
