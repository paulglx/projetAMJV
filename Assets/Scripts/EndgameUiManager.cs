using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndgameUiManager : MonoBehaviour
{

    [SerializeField] private GameObject statusText;
    private TextMeshProUGUI statusTextTMP;

    void Start()
    {
        statusTextTMP = statusText.GetComponent<TextMeshProUGUI>();
    }

    public void SetStatus(string status)
    {
        statusTextTMP.SetText(status);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
