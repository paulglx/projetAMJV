using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> selectedPlayers;

    // Start is called before the first frame update
    void Start()
    {
        selectedPlayers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        // Raycast from mouse position into the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if raycast hit something
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log(target);

            // A player is clicked : select it
            if (target.CompareTag("Player"))
            {

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    //Remove colors
                    foreach (GameObject selectedPlayer in selectedPlayers)
                        UnsetSelectedColor(selectedPlayer);

                    selectedPlayers = new List<GameObject>();
                }

                selectedPlayers.Add(target);
                SetSelectedColor(target);
            }
            // No active selected player : do nothing
            else if (selectedPlayers.Count == 0)
            {
                return;
            }
            // Something with health is clicked : attack it
            else if (target.GetComponent<Health>())
            {
                foreach (GameObject selectedPlayer in selectedPlayers)
                    selectedPlayer.GetComponent<Attack>().SetTarget(target);
            }
            // Another object is clicked : move there
            else
            {
                foreach (GameObject selectedPlayer in selectedPlayers)
                    selectedPlayer.GetComponent<Attack>().SetTarget(null);

                Vector3 point = hit.point;
                foreach (GameObject selectedPlayer in selectedPlayers)
                    selectedPlayer.GetComponent<MovementManager>().GoToPoint(point);
            }
        }
    }

    void SetSelectedColor(GameObject player)
    {

        Color selectionColor = new(0.0f, 0.9f, 0.0f);
        Material mat = player.GetComponentInChildren<Renderer>().material;

        mat.SetColor("_Color", selectionColor);

    }

    void UnsetSelectedColor(GameObject player)
    {
        Color selectionColor = new(1.0f, 1.0f, 1.0f);
        Material mat = player.GetComponentInChildren<Renderer>().material;

        mat.SetColor("_Color", selectionColor);
    }
}
