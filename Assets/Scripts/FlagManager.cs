using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
public class FlagManager : MonoBehaviour
{
    public UnityEvent<GameObject> FlagCaptured; 
    private bool isCaptured;

    // Start is called before the first frame update
    void Start()
    {
        isCaptured= false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    private void AttachFlag(GameObject player )
    {
        this.gameObject.transform.parent = player.transform; 
        Destroy(player.GetComponent<Attack>());
        player.GetComponent<MovementManager>().GoToPoint(new Vector3(4.5f,0,-7.5f));
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
        Debug.Log("Fin de la game");
    }
}
