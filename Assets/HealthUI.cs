using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Living creature;
    public GameObject camera;

    public Slider slider;
    public Text healthText;
    public Text hungerText;
    public Text Tiredness;
    // Use this for initialization
    void Start()
    {
        creature = GetComponent<Living>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = creature.currentLife;
        healthText.text = "Health: " + creature.currentLife + "/" + creature.maxLife;
        hungerText.text = "Hunger: " + creature.currentHunger + "/" + creature.maxHunger;
        Tiredness.text = "Tiredness: " + creature.currentEnergy + "/" + creature.maxEnergy;
        if (creature.currentLife <= 0)
        {
            healthText.text = "Health: " + 0 + "/" + creature.maxLife;
        }  
    }
}
