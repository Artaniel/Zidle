using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    public static Boot instance;

    public static HumanFactory humanFactory { get => instance._humanFactory; }
    [SerializeField] private HumanFactory _humanFactory;
    public static ZombieFactory zombieFactory { get => instance._zombieFactory; }
    [SerializeField] private ZombieFactory _zombieFactory;
    public static GameField gameField { get => instance._gameField; }
    [SerializeField] private GameField _gameField;
    public static Level level { get => instance._level; }
    [SerializeField] private Level _level;

    private void Awake()
    {
        instance = this;
        humanFactory.Init();
        zombieFactory.Init();
    }

}
