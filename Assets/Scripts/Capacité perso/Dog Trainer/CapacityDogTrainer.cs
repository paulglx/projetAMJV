using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityDogTrainer : Capacity
{

    // Also replaces Attack for the DogTrainer

    [SerializeField] private float spawnDistance;
    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private List<GameObject> dogs;
    [SerializeField] private uint maxDogs;

    // Start is called before the first frame update
    void Start()
    {
        dogs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    public override bool Use(GameObject target = null, Vector3 point = default)
    {
        if (dogs.Count < maxDogs)
        {
            GameObject newDog = Instantiate(dogPrefab, transform.position + transform.forward * spawnDistance, transform.rotation);
            dogs.Add(newDog);
            newDog.GetComponent<Dog>().SetDogTrainer(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                SetTarget(hit.collider.gameObject);
            }
        }
    }

    void SetTarget(GameObject target)
    {
        foreach (GameObject dog in dogs)
        {
            dog.GetComponent<Attack>().SetTarget(target);
        }
    }
}
