using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.layer == 8)
        {
            EndGame();
        }            
     
    }

    private void EndGame()
    {
        Debug.Log("End Game Win ");
    }
}
