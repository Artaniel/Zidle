using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopItemPrefab;
    public List<ShopItem> items;
    public ShopItem bloodForAttackSpeedItem;

    public void Init() {
        bloodForAttackSpeedItem = Instantiate(shopItemPrefab).GetComponent<ShopItem>();
        bloodForAttackSpeedItem.transform.SetParent(transform);
        bloodForAttackSpeedItem.Init(Boot.economy.blood, Boot.economy.attackSpeed);
    }
}
