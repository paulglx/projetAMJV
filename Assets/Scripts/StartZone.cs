using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{

    [SerializeField] private GameObject endgameUi;

    // Start is called before the first frame update
    void Start()
    {
        endgameUi.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<FlagManager>())
        {
            EndGame();
        }

    }

    private void EndGame()
    {
        Debug.Log("End Game Win ");
        endgameUi.SetActive(true);
    }
}
