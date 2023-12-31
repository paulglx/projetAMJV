using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    [SerializeField] private GameObject healthBarFull;
    private GameObject healthBarCanvas;
    private float targetFillAmount;
    private Health parentHealth;
    private Image healthBarFullImage;

    // Start is called before the first frame update
    void Start()
    {
        parentHealth = GetComponentInParent<Health>();
        healthBarFullImage = healthBarFull.GetComponent<Image>();
        healthBarCanvas = GetComponentInChildren<Canvas>().gameObject;

        targetFillAmount = parentHealth.GetHealth() / parentHealth.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarFullImage.fillAmount = Mathf.Lerp(healthBarFullImage.fillAmount, targetFillAmount, 0.5f * Time.deltaTime * 60);
        healthBarCanvas.SetActive(healthBarFullImage.fillAmount < 1);
    }

    public void UpdateHealthbar()
    {
        float maxHealth = parentHealth.GetMaxHealth();
        float health = parentHealth.GetHealth();

        targetFillAmount = health / maxHealth;
    }
}
