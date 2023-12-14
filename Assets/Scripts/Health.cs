using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    [SerializeField] private float shield;

    [SerializeField] private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Heal(float healthPoints)
    {
        health += Mathf.Min(maxHealth, health + healthPoints);
    }

    public void ApplyDamage(float damage)
    {
        health -= Mathf.Max(damage - shield, 0);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("I am " + gameObject.name + " and i'm dead");
        Destroy(gameObject);
    }
}
