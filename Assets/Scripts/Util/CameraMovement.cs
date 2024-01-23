using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector3(1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector3(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector3(0f, 0f, -1f);
        }

        transform.position += movementSpeed * Time.deltaTime * direction;
    }



}
