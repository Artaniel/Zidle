using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    public float energy = 0;
    public float maxEnergy = 10;
    public float energyRegen = 1f;
    public TextMeshProUGUI energyText;
    public float zombiePrice = 10;

    private void Update() {
        energy = Mathf.Clamp(energy + energyRegen * Time.deltaTime, 0f, maxEnergy);
        RefreshUI();
    }

    private void RefreshUI() {
        energyText.text = $"{energy:0.00}/{maxEnergy}";
    }

    public bool CanSpawn() {
        return energy >= zombiePrice;
    }

    public void SpendEnergyOnZombie() {
        energy -= zombiePrice;
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
    }

}
