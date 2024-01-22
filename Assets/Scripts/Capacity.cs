using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;
    [SerializeField] private float range;
    [SerializeField] private bool canBeUsedOnPlayer = false;
    [SerializeField] private bool canBeUsedOnFloor = false;
    [SerializeField] private bool canBeUsedOnNothing = false;

    private float lastUseTime;


    public abstract bool Use(GameObject target = null, Vector3 point = default);

    void Start()
    {
        lastUseTime = Time.time;
    }

    public void TryToUse(GameObject target, Vector3 point)
    {
        if (!CanBeUsed(target, point))
        {
            return;
        }

        if (Time.time - lastUseTime >= cooldown)
        {
            if (isInRange(target, point))
            {
                bool hasUsed = Use(target, point);
                if (hasUsed)
                {
                    lastUseTime = Time.time;
                }
            }

        }
        else
        {
            Debug.Log("I can use my capacity in " + (cooldown - (Time.time - lastUseTime)) + " seconds");
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

        if (canBeUsedOnNothing)
        {
            return true;
        }

        return false;
    }

    private bool CanBeUsed(GameObject target, Vector3 point)
    {
        if ((target == null) & (!canBeUsedOnFloor) & (!canBeUsedOnNothing))
        {
            Debug.Log("I need a target to use my capacity");
            return false;
        }
        else if ((point == default) & (!canBeUsedOnPlayer) & (!canBeUsedOnNothing))
        {
            Debug.Log("I need a point to use my capacity");
            return false;
        }
        else if (!canBeUsedOnNothing)
        {
            Debug.Log("I can't use my capacity on nothing");
            return false;
        }
        return true;
    }


    public float GetLastUseTime()
    {
        return lastUseTime;
    }

    public float GetCooldown()
    {
        return cooldown;
    }


}
