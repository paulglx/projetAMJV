using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityDoctor : Capacity
{

    [SerializeField] private bool forceEnrage;
    [SerializeField] private float healAmount;
    [SerializeField] private float rageDuration;
    [SerializeField] private float rageMultiplier;
    [SerializeField] private GameObject healEffect;
    [SerializeField] private GameObject rageEffect;
    [SerializeField] private List<GameObject> customers;
    private GameObject rageEffectInstance;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        customers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if customers are still alive. If a customer died, enrage the doctor.
        foreach (GameObject customer in customers)
        {
            if (!customer)
            {
                Enrage();
            }
        }

        // Remove dead customers from the list
        customers.RemoveAll(item => item == null);
    }

    private void OnValidate()
    {
        if (forceEnrage)
        {
            Enrage();
            forceEnrage = false;
        }
    }

    private IEnumerator RageTimer()
    {
        yield return new WaitForSeconds(rageDuration);
        GetComponent<Attack>().SetDamage(GetComponent<Attack>().GetDamage() / rageMultiplier);
        GetComponent<Attack>().SetRange(GetComponent<Attack>().GetRange() / rageMultiplier);
        Destroy(rageEffectInstance);
    }

    public void Enrage()
    {
        Debug.Log("A customer died, I become filled with rage");
        GetComponent<Attack>().SetDamage(GetComponent<Attack>().GetDamage() * rageMultiplier);
        GetComponent<Attack>().SetRange(GetComponent<Attack>().GetRange() * rageMultiplier);

        rageEffectInstance = Instantiate(rageEffect, transform.position, Quaternion.identity, transform);

        StartCoroutine(RageTimer());
    }

    public override bool Use(GameObject target = null, Vector3 point = default)
    {
        if (target == null)
        {
            return false;
        }

        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth && !target.CompareTag("Enemy"))
        {
            targetHealth.Heal(healAmount);
            Instantiate(healEffect, target.transform.position, Quaternion.identity, target.transform);
            customers.Add(target);
            return true;
        }
        else
        {
            return false;
        }
    }
}
