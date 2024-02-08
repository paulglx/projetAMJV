using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> selectedPlayers;
    private Hashtable playersBaseColors;
    private DescriptionManager descriptionManager;

    // Start is called before the first frame update
    void Start()
    {
        selectedPlayers = new List<GameObject>();
        playersBaseColors = new Hashtable();
        descriptionManager = FindAnyObjectByType<DescriptionManager>();

        Assert.IsNotNull(descriptionManager, "Your scene is missing a DescriptionManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Unselect();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            HandleCapacity();
        }
    }

    void Select(GameObject player)
    {
        selectedPlayers.Add(player);
        SetSelectedColor(player);

        UpdateDescription();
    }

    void UpdateDescription()
    {
        if (selectedPlayers.Count == 1)
        {
            descriptionManager.Select(selectedPlayers[0]);
        }
        else
        {
            descriptionManager.Unselect();
        }
    }

    void Unselect()
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
            UnsetSelectedColor(selectedPlayer);

        selectedPlayers = new List<GameObject>();

        UpdateDescription();
    }

    void HandleCapacity(Vector3 point)
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
            selectedPlayer.GetComponent<Capacity>().TryToUse(null, point);
    }

    void HandleCapacity(GameObject target)
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
            selectedPlayer.GetComponent<Capacity>().TryToUse(target, target.transform.position);
    }

    void HandleCapacity()
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
            selectedPlayer.GetComponent<Capacity>().TryToUse(null, new Vector3(-100, -100, -100));
    }

    void HandleClick()
    {
        // Raycast from mouse position into the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if raycast hit something
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log("Clicked object : " + target);

            // Capacity key is held : use capacity
            if (Input.GetKey(KeyCode.A))
            {
                if (target.CompareTag("Enemy") || target.CompareTag("Player"))
                {
                    HandleCapacity(target);
                }
                else
                {
                    HandleCapacity(hit.point);
                }
                return;
            }

            // A player is clicked : select it
            if (target.CompareTag("Player"))
            {

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    Unselect();
                }

                Select(target);
            }
            // No active selected player : do nothing
            else if (selectedPlayers.Count == 0)
            {
                return;
            }
            // Something with health is clicked : attack it
            else if (target.GetComponent<Health>())
            {
                AttackTarget(target);
            }
            // Another object is clicked : move there
            else
            {
                Vector3 point = hit.point;
                GoToTarget(point);
            }
        }
    }

    void AttackTarget(GameObject target)
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
        {
            PlayerController player = selectedPlayer.GetComponent<PlayerController>();
            if (player)
            {
                player.TransitionToState(new AttackState(player, target));
            }
        }
    }

    void GoToTarget(Vector3 targetPoint)
    {
        foreach (GameObject selectedPlayer in selectedPlayers)
        {
            Attack attack = selectedPlayer.GetComponent<Attack>();
            if (attack)
            {
                attack.SetTarget(null);
            }

            PlayerController player = selectedPlayer.GetComponent<PlayerController>();
            if (player)
            {
                player.GoTo(targetPoint);
            }
        }
    }

    void SetSelectedColor(GameObject player)
    {

        Material mat = player.GetComponentInChildren<Renderer>().material;
        int playerId = player.GetInstanceID();

        if (!playersBaseColors.ContainsKey(playerId))
        {
            Color oldColor = mat.GetColor("_Color");
            playersBaseColors.Add(playerId, oldColor);
        }

        Color selectionColor = new(0.0f, 0.9f, 0.0f);

        mat.SetColor("_Color", selectionColor);

    }

    void UnsetSelectedColor(GameObject player)
    {

        Color oldColor = (Color)playersBaseColors[player.GetInstanceID()];

        Material mat = player.GetComponentInChildren<Renderer>().material;

        mat.SetColor("_Color", oldColor);
    }
}
