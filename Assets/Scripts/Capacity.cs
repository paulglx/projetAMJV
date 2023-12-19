using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    private float lastUseTime;

    private Attack attack;

    public abstract bool Use(GameObject target = null, Vector3 point = default);

    void Start()
    {
        attack = GetComponent<Attack>();
        lastUseTime = Time.time;
    }

    public void TryToUse(Vector3 point)
    {

        Debug.Log("I am " + gameObject.name + " and i try to use my capacity at " + point);

        if (Time.time - lastUseTime >= cooldown)
        {
            GameObject target = attack.GetTarget();

            bool hasUsed = Use(target, point);
            if (hasUsed)
                lastUseTime = Time.time;
        }
    }

}
