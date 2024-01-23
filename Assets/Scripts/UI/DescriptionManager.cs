using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{

    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject capacityDescriptionTMP;
    [SerializeField] private GameObject capacityTimerCircle;
    [SerializeField] private GameObject descriptionTMP;
    [SerializeField] private GameObject nameTMP;
    [SerializeField] private GameObject player;
    private Capacity playerCapacity;

    private void Start()
    {
        player = null;
        Unselect();
    }

    private void Update()
    {
        if (player != null)
            UpdateTimer();
    }

    void UpdateTimer()
    {
        if (playerCapacity != null)
        {
            float cooldown = playerCapacity.GetCooldown();
            float lastUseTime = playerCapacity.GetLastUseTime();
            float timeSinceLastUse = Time.time - lastUseTime;
            float timeLeft = cooldown - timeSinceLastUse;
            float percentage = 1 - timeLeft / cooldown;
            capacityTimerCircle.GetComponent<Image>().fillAmount = percentage;
        }
    }

    public void UpdateDescription(Description newDescription)
    {
        nameTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.displayName;
        descriptionTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.description;
        capacityDescriptionTMP.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription.capacityDescription;
    }

    public void Select(GameObject player)
    {
        this.player = player;
        playerCapacity = player.GetComponent<Capacity>();
        UpdateDescription(player.GetComponent<Description>());
        backgroundPanel.SetActive(true);
    }

    public void Unselect()
    {
        backgroundPanel.SetActive(false);
    }
}
