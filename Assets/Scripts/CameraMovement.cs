using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    public void movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1f,0f,0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1f,0f,0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f,0f,1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f,0f,-1f);
        }

    }
}
