using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FlagManager : MonoBehaviour
{
    public UnityEvent<GameObject> FlagCaptured;
    private bool isCaptured;
    private GameObject startZone;

    // Start is called before the first frame update
    void Start()
    {
        isCaptured = false;
        startZone = FindFirstObjectByType<StartZone>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void AttachFlag(GameObject player)
    {
        gameObject.transform.parent = player.transform;
        Destroy(player.GetComponent<Attack>());
        player.GetComponent<MovementManager>().GoToPoint(startZone.transform.position);
        FlagCaptured.Invoke(player);
        isCaptured = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isCaptured)
        {
            if (other.gameObject.layer == 6)
            {
                AttachFlag(other.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        EndgameUiManager endgameUiManager = FindAnyObjectByType<EndgameUiManager>(FindObjectsInactive.Include);
        endgameUiManager?.SetStatus("You lose");
        endgameUiManager?.Show();
    }
}
