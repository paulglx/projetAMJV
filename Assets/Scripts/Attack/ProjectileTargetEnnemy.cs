using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProjectileTargetEnnemy : MonoBehaviour
{

    private GameObject targetEnnemy;
    private Vector3 initialPosition;
    [SerializeField] private float speed;

    private float damage;

    [SerializeField] private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;

        // Vérification des composants
        Assert.IsNotNull(GetComponent<Rigidbody>(), "The projectile needs a rigidbody");
        Assert.IsNotNull(GetComponent<Collider>(), "The projectile needs a trigger collider");
        Assert.IsTrue(GetComponent<Collider>().isTrigger, "The projectile collider needs to be a trigger");
    }

    // Update is called once per frame
    void Update()
    {

        if (targetEnnemy == null)
        {
            MoveToPosition();
        }
        else
        {
            MoveProjectile();
        }



    }


    private void MoveToPosition()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }



    }

    private void MoveProjectile()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetEnnemy.transform.position + new Vector3(0, 1 - targetEnnemy.transform.position.y, 0), speed * Time.deltaTime);

        if (transform.position == targetEnnemy.transform.position)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }

        targetPosition = targetEnnemy.transform.position;
        transform.forward = targetEnnemy.transform.position + new Vector3(0, 1 - targetEnnemy.transform.position.y, 0) - transform.position;
    }




    void OnTriggerEnter(Collider other)
    {
        //Pas de tir allié
        if (other.CompareTag("Player"))
        {
            return;
        }

        Health targetHealth = other.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.ApplyDamage(damage);
        }
        Destroy(gameObject);
    }

    public void SetProjectile(Vector3 iniPosition, GameObject targEnnemy, float dam)
    {
        initialPosition = iniPosition;
        targetEnnemy = targEnnemy;
        initialPosition.y = 1;
        damage = dam;
        transform.forward = targetEnnemy.transform.position - iniPosition;

    }
}
