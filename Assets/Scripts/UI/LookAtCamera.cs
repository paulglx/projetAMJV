using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Look at camera.
        // Only compute and change rotation if the position has changed.

        Vector3 positionDiff = transform.position - cam.transform.position;
        if (positionDiff != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.position - cam.transform.position);
            transform.rotation = newRotation;
        }
    }
}
