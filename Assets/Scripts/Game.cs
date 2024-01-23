using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private Time temps; 
    private int numberOfEnemies;

    private GameObject king; 

    




    // Start is called before the first frame update
    void Start()
    {        
        SubscribeToFlag();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetTheKing(GameObject player)
    {
        king = player;
    }

    private void SubscribeToFlag()
    {
        flag = GameObject.Find("Flag");

        if (flag != null)
        {
            flag.GetComponent<FlagManager>().FlagCaptured.AddListener(SetTheKing);
        }
        else
        {
            Debug.LogWarning("The gameObject \"Flag\" is not found in the current scene.");
        }
    }


    public void OneDie()
    {
        numberOfEnemies -=1;
    }
}
