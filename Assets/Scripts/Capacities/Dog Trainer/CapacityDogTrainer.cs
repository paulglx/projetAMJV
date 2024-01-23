using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CapacityDogTrainer : Capacity
{

    // Also replaces Attack for the DogTrainer

    [SerializeField] private float spawnDistance;
    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private List<GameObject> dogs;
    [SerializeField] private uint maxDogs;

    // Start is called before the first frame update
    public override void Start()
    {
        dogs = new List<GameObject>();
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

    public void SetDogsTarget(GameObject target)
    {

        // Remove dogs if they are dead
        dogs = dogs.Where(dog => dog != null).ToList();

        foreach (GameObject dog in dogs.ToList())
        {

            dog.GetComponent<Attack>().SetTarget(target);
        }
    }
}
