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
    private GlobalStat stat;

    private void Start()
    {
        Boot.economy.ShopItemRegister(this);
    }

    public void Init(EconomyResource resource, GlobalStat stat) { 
        priceResource = resource;
        this.stat = stat;
    }

    public string GetTooltip() {
        float price = GetPrice();
        boughtCount++;
        return $"Buy {statName} {buyAmmount} \n for {boughtCount} {resourceName}";
    }

    public void TryBuy() {
        float price = GetPrice();
        if (priceResource.value >= price) {
            priceResource.value -= price;
            stat.Change(buyAmmount);
            boughtCount++;
        }
    }

    private float GetPrice() {
        return (boughtCount + 1) * 0.1f;
    }
}
