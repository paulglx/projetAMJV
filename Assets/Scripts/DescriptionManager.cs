using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{

    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject nameTMP;
    [SerializeField] private GameObject descriptionTMP;
    [SerializeField] private GameObject capacityDescriptionTMP;

    public void UpdateDescription(Description newDescription)
    {
        nameTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.displayName;
        descriptionTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.description;
        capacityDescriptionTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.capacityDescription;

        Show();
    }

    public void Show()
    {
        backgroundPanel.SetActive(true);
    }

    public void Hide()
    {
        backgroundPanel.SetActive(false);
    }
}
