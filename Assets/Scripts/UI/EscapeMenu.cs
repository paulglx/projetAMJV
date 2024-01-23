using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{

    private bool visible;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        canvas.gameObject.SetActive(visible);
        Time.timeScale = visible ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
        }
    }
}
