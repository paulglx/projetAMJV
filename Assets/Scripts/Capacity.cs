using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacity : MonoBehaviour
{

    [SerializeField] private float cooldown;

    private float lastUseTime;

    public abstract void Use();

    void Start()
    {
        lastUseTime = Time.time;
    }

    public void TryToUse()
    {
        if (Time.time - lastUseTime >= cooldown)
        {
            Use();
            lastUseTime = Time.time;
        }
    }

}
