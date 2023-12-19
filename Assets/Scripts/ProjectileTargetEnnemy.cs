using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {

        if (targetEnnemy==null)
        {
            moveToPosition();
        }
        else
        {
            moveProjectile();
        }
        

        
    }


    private void moveToPosition()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed* Time.deltaTime);

        if (transform.position == targetPosition)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }



    }

    private void moveProjectile()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetEnnemy.transform.position + new Vector3(0,1-targetEnnemy.transform.position.y,0), speed* Time.deltaTime);

        if (transform.position == targetEnnemy.transform.position)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }

        targetPosition = targetEnnemy.transform.position;
        transform.forward = targetEnnemy.transform.position + new Vector3(0,1-targetEnnemy.transform.position.y,0) - transform.position;
    }




    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger");
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
        initialPosition.y = 1;
        damage = dam;
        transform.forward = targetEnnemy.transform.position - iniPosition;

    }
}
