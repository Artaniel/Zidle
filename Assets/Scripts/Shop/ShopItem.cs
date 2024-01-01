using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public string statName;
    public string resourceName;
    private int boughtCount = 0;
    public float buyAmmount = 0.1f;
    private EconomyResource priceResource;

    public void Init(EconomyResource resource) { 
        priceResource = resource;
    }

    public string GetTooltip() {
        float price = GetPrice();
        boughtCount++;
        return $"Buy {statName} {buyAmmount} \n for {boughtCount} {resourceName}";
    }

    private void OnMouseDown() {
        TryBuy();
    }

    private void TryBuy() {
        float price = GetPrice();
        if (priceResource.value >= price) {
            priceResource.value -= price;
            //add stat... как его определить то? enum?
        }
    }

    private float GetPrice() {
        return (boughtCount + 1) * 0.1f;
    }
}
