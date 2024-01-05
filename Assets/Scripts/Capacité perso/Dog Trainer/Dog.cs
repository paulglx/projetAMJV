using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    [SerializeField] private bool isLost;
    [SerializeField] private GameObject dogTrainer;
    private Attack attack;
    private MovementManager movementManager;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        movementManager = GetComponent<MovementManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isLost)
        {
            movementManager.GoToPoint(transform.position + transform.forward + transform.right);
            return;
        }

        if (attack.GetTarget() == null)
        {
            movementManager.GoToPoint(dogTrainer.transform.position);
        }

        if (!isLost)
        {
            if (dogTrainer == null)
            {
                isLost = true;
            }
        }
    }

    public void SetDogTrainer(GameObject dogTrainer)
    {
        this.dogTrainer = dogTrainer;
        isLost = false;
    }
}
