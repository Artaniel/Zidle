using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boot : MonoBehaviour
{
    public static Boot instance;

    public UI ui;
    public HumanFactory humanFactory;
    public ZombieFactory zombieFactory;
    public Level level;
    public Economy economy;

    public List<ManualMonobehaviour> toInit;
    public List<ManualMonobehaviour> toUpdate;

    private void Awake() {
        instance = this;
        level.Init(this);       

        humanFactory.Init(this);
        zombieFactory.Init(this);
        economy.Init(this);

        ui.Init(this);

        foreach (ManualMonobehaviour item in toInit)
            item.Init(this);
    }

    private void Update() {
        foreach (ManualMonobehaviour item in toUpdate)
            item.ManualUpdate();        
    }
}
