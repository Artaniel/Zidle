using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public float zombiePrice = 10;
    public Energy energy;
    public ResoursePrototype enegryPrototype;
    public TextMeshProUGUI uiResourcesText;

    public void Init() {
        energy = Energy.Instantiate(enegryPrototype);
    }

    private void Update() {
        RefreshUI();
    }

    private void RefreshUI() {
        uiResourcesText.text = "";
        // foreach resouces
        uiResourcesText.text += energy.GetUIString()+ '\n';
    }

    public bool CanSpawn() {
        return energy.value >= zombiePrice;
    }

    public void SpendEnergyOnZombie() {
        energy.value = Mathf.Clamp(energy.value-zombiePrice, 0, energy.max);
    }

}
