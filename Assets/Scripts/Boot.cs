using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    public static Boot instance;


    [SerializeField] private HumanFactory _humanFactory;
    public static HumanFactory humanFactory { get => instance._humanFactory; }

    


    private void Awake()
    {
        instance = this;
    }

}
