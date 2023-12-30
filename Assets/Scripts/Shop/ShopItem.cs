using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public string statName;
    public string resourceName;
    private int boughtCount = 0;
    public float buyAmmount = 0.1f;

    public string GetTooltip() {
        float price = (boughtCount + 1) * 0.1f;
        boughtCount++;
        return $"Buy {statName} {buyAmmount} \n for {boughtCount} {resourceName}";
    }
}
