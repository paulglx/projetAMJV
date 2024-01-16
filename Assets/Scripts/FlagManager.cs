using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    private AttachFlag(GameObject player )
    {
        this.transform.parent = player; 
        Destroy(player.GetComponent<Attack>);
        player.GetCompo
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.layer == 6)
        {
            AttachFlag(other.gameObject);

        }
        
    }


    private void OnTriggerEnter(Collider other) 
    {
        
    }
}
