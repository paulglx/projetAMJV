using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{



    [SerializeField] private bool isAlive;
    [SerializeField] private bool forceDamage;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float shield;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Vector3 healthBarPosition;
    private GameObject healthBar;
    private HealthBarManager healthBarManager;

    // Start is called before the first frame update
    void Start()
    {
        //        isAlive = true;
        health = maxHealth;

        // Instantiate Health bar prefab inside parent
        healthBar = Instantiate(healthBarPrefab, gameObject.transform);
        healthBar.transform.Translate(healthBarPosition);

        healthBarManager = healthBar.GetComponent<HealthBarManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnValidate()
    {
        if (forceDamage)
        {
            ApplyDamage(10);
            forceDamage = false;
        }
    }

    public void Heal(float healthPoints)
    {
        health = Mathf.Min(health + healthPoints, maxHealth);

        healthBarManager.UpdateHealthbar();
    }

    public void ApplyDamage(float damage)
    {
        health -= Mathf.Max(damage - shield, 0);

        if (health <= 0)
        {
            Die();
        }

        healthBarManager.UpdateHealthbar();
    }

    void Die()
    {
        //Debug.Log("I am " + gameObject.name + " and i'm dead");
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
