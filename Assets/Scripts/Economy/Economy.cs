using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    private Boot _boot;
    public float zombiePrice = 10;
    public TextMeshProUGUI uiResourcesText;
    [HideInInspector] public EconomyResource energy;
    public ResoursePrototype energyPrototype;
    [HideInInspector] public EconomyResource blood;
    public ResoursePrototype bloodPrototype;
    [HideInInspector] public GlobalStat attackSpeed;

    public void Init(Boot boot) {
        _boot = boot;
        energy = EconomyResource.Instantiate(energyPrototype);
        blood = EconomyResource.Instantiate(bloodPrototype);
        attackSpeed = new GlobalStat(1);
    }

    private void Update() {
        energy.ApplyRegen();
        RefreshUI();
    }

    private void RefreshUI() {
        uiResourcesText.text = "";
        // foreach resouces
        uiResourcesText.text += $"{energy.GetUIString()}\n";
        uiResourcesText.text += $"{blood.GetUIString()}\n";
    }

    public bool CanSpawn() {
        return energy.value >= zombiePrice;
    }

    public void SpendEnergyOnZombie() {
        energy.value = Mathf.Clamp(energy.value - zombiePrice, 0, energy.max);
    }

    public void OnAttack(Character attacker) {
        blood.Change(1);
    }
}
