using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    private float lastUseTime;

    public abstract void Use(GameObject target = null);

    public Attack attack;

    void Start()
    {
        attack = GetComponent<Attack>();
        lastUseTime = Time.time;
    }

    public void TryToUse()
    {
        if (Time.time - lastUseTime >= cooldown)
        {
            Use(attack.GetTarget());
            lastUseTime = Time.time;
        }
    }

}
