using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{

    private EndgameUiManager endgameUiManager;

    // Start is called before the first frame update
    void Start()
    {
        endgameUiManager = FindObjectOfType<EndgameUiManager>();
        endgameUiManager.Hide();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            EndGame();
        }

    }

    private void StopAllActions()
    {
        Attack[] attacks = FindObjectsByType<Attack>(FindObjectsSortMode.None);
        foreach (var atk in attacks)
        {
            atk.SetTarget(null);
        }

        MovementManager[] movementManagers = FindObjectsByType<MovementManager>(FindObjectsSortMode.None);
        foreach (var mvt in movementManagers)
        {
            mvt.GoToPoint(mvt.gameObject.transform.position);
        }
    }

    private void EndGame()
    {
        StopAllActions();
        endgameUiManager.SetStatus("You win!");
        endgameUiManager.Show();
    }
}
