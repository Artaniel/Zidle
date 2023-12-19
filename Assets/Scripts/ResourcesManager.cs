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

    private void Update() {
        energy += energyRegen * Time.deltaTime;
    }

    private void RefreshUI() {
        energyText.text = $"{energy}/{maxEnergy}";
    }

}
