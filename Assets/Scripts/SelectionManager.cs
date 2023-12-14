using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private GameObject selectedPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!selectedPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from mouse position into the world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if raycast hit something
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject target = hit.collider.gameObject;
                Debug.Log(target);

                if (target.GetComponent<Health>())
                {
                    selectedPlayer.GetComponent<Attack>().SetTarget(target);
                }
                else
                {
                    selectedPlayer.GetComponent<Attack>().SetTarget(null);

                    Vector3 point = hit.point;
                    selectedPlayer.GetComponent<MovementManager>().GoToPoint(point);
                }
            }
        }
    }
}
