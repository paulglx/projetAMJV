using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class EndgameUiManager : MonoBehaviour
{

    [SerializeField] private GameObject statusText;
    private TextMeshProUGUI statusTextTMP;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        Hide();

        statusTextTMP = statusText.GetComponent<TextMeshProUGUI>();
    }

    public void SetStatus(string status)
    {
        statusTextTMP.SetText(status);
    }

    public void Show()
    {
        if (canvas)
            canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (canvas)
            canvas.gameObject.SetActive(false);
    }
}
