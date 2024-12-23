using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boot : MonoBehaviour
{
    public static Boot instance;

    public HumanFactory humanFactory;
    public ZombieFactory zombieFactory;
    public Level level;
    public Economy economy;
    public Shop shop;

    private void Awake()
    {
        instance = this;
        level.Init(this);       

        humanFactory.Init(this);
        zombieFactory.Init(this);
        economy.Init(this);
        shop.Init(this);
    }

}
