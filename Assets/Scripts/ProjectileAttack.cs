using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{

    private GameObject targetEnnemy; 
    private Vector3 initialPosition; 
    [SerializeField] private float speed;

    [SerializeField] private float damage;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition; 
        
    }

    // Update is called once per frame
    void Update()
    {

        moveToTarget();

        
    }


    private void moveToTarget()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetEnnemy.transform.position, speed* Time.deltaTime);

        if (transform.position == targetEnnemy.transform.position)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }
    }


    private void OnCollisionStay(Collision other) 
    {
        Debug.Log("OnCollision");
        Health targetHealth = other.gameObject.GetComponent<Health>();
        //Pas de tir allié
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        else if (targetHealth)
        {
            targetHealth.ApplyDamage(damage);
            Debug.Log("J'ai fait des dégats");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Je me suis cogner");
            Destroy(gameObject);
        }
        
    }

    void OnTriggerStay(Collider other) 
    {
        Health targetHealth = other.GetComponent<Health>();
        //Pas de tir allié
        if (other.CompareTag("Player"))
        {
            
        }
        else if (targetHealth)
        {
            targetHealth.ApplyDamage(damage);
            Debug.Log("J'ai fait des dégats");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Je me suis cogner");
            Destroy(gameObject);
        }
    } 
    
    public void setProjectile(Vector3 iniPosition, GameObject targEnnemy, float dam)
    {
        initialPosition = iniPosition;
        targetEnnemy = targEnnemy;
        damage = dam;
        transform.forward = targetEnnemy.transform.position - iniPosition;

    }

}
