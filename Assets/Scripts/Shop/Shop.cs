using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Boot _boot;
    public GameObject shopItemPrefab;
    public List<ShopItem> items;
    public ShopItem bloodForAttackSpeedItem;

    public void Init(Boot boot) {
        _boot = boot;
        bloodForAttackSpeedItem = Instantiate(shopItemPrefab).GetComponent<ShopItem>();
        bloodForAttackSpeedItem.transform.SetParent(transform);
        bloodForAttackSpeedItem.Init(Boot.economy.blood, Boot.economy.attackSpeed);
    }
}
