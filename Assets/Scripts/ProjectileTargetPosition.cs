using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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

        // Vérification des composants
        Assert.IsNotNull(GetComponent<Rigidbody>(), "The projectile needs a rigidbody");
        Assert.IsNotNull(GetComponent<Collider>(), "The projectile needs a trigger collider");
        Assert.IsTrue(GetComponent<Collider>().isTrigger, "The projectile collider needs to be a trigger");
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }


    private void MoveProjectile()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }



    void OnTriggerEnter(Collider other)
    {
        // Ignore collisions with players
        if (other.gameObject.CompareTag("Player"))
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

    public void SetProjectile(Vector3 iniPosition, Vector3 targPosition, float dam)
    {

        initialPosition = iniPosition + new Vector3(0, 1, 0);
        targetPosition = targPosition + new Vector3(0, 1, 0);
        initialPosition.y = 1;
        targetPosition.y = 1;

        damage = dam;
        transform.forward = targetPosition - initialPosition;
    }
}
