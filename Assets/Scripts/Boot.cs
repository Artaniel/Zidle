using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boot : MonoBehaviour
{
    public static Boot instance;

    public static HumanFactory humanFactory { get => instance._humanFactory; }
    [SerializeField] private HumanFactory _humanFactory;
    public static ZombieFactory zombieFactory { get => instance._zombieFactory; }
    [SerializeField] private ZombieFactory _zombieFactory;
    public static Level level { get => instance._level; }
    [SerializeField] private Level _level;
    public static ResourcesManager resourcesManager { get => instance._resourcesManager; }
    [SerializeField] private ResourcesManager _resourcesManager;


    private void Awake()
    {
        instance = this;
        level.Init();       

        humanFactory.Init();
        zombieFactory.Init();
    }

}
