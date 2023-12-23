using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public float zombiePrice = 10;
    public Energy energy;
    public ResoursePrototype enegryPrototype;

    public void Init() {
        energy = Energy.Instantiate(enegryPrototype);
    }

    private void Update() {
        RefreshUI();
    }

    private void RefreshUI() {
        //energyText.text = $"{energy:0.00}/{maxEnergy}";
    }

    public bool CanSpawn() {
        return energy.value >= zombiePrice;
    }

    public void SpendEnergyOnZombie() {
        energy.value = Mathf.Clamp(energy.value-zombiePrice, 0, energy.max);
    }

}
