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


    private void AttachFlag(GameObject player )
    {
        this.gameObject.transform.parent = player.transform; 
        Destroy(player.GetComponent<Attack>());
        player.GetComponent<MovementManager>().GoToPoint(new Vector3(0,0,0));
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
