using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public float zombiePrice = 10;
    public EconomyResource energy;
    public ResoursePrototype enegryPrototype;
    public TextMeshProUGUI uiResourcesText;

    public void Init() {
        energy = EconomyResource.Instantiate(enegryPrototype);
    }

    private void Update() {
        energy.ApplyRegen();
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
