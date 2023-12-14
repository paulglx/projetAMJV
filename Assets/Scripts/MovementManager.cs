using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetClickPositionAndMove();
        }
    }

    void GetClickPositionAndMove()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        // Raycast from mouse position into the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if raycast hit something
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            agent.SetDestination(point);
        }
    }
}
