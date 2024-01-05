using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTargetPosition : MonoBehaviour
{


    [SerializeField] private float speed;
    private float damage;
    private Vector3 initialPosition;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;

    }

    // Update is called once per frame
    void Update()
    {

        MoveProjectile();

    }


    private void MoveProjectile()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            Debug.Log("arriver");
            Destroy(gameObject);
        }
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

    public void SetProjectile(Vector3 iniPosition, Vector3 targPosition, float dam)
    {
        initialPosition = iniPosition + new Vector3(0, 1, 0);
        targetPosition = targPosition + new Vector3(0, 1, 0);
        initialPosition.y = 1;
        targetPosition.y = 1;

        damage = dam;
        transform.forward = targetPosition - iniPosition;

    }

}
