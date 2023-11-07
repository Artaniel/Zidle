using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    public static Boot instance;


    public static HumanFactory humanFactory { get => instance._humanFactory; }
    [SerializeField] private HumanFactory _humanFactory;
    public static GameField gameField { get => instance._gameField; }
    [SerializeField] private GameField _gameField;




    private void Awake()
    {
        instance = this;
    }

}
