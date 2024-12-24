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

    public List<IGenericBootable> genericBootables;
    public List<IUpdatable> updatables;

    private void Awake()
    {
        instance = this;
        level.Init(this);       

        humanFactory.Init(this);
        zombieFactory.Init(this);
        economy.Init(this);

        ui.Init(this);

        genericBootables.ForEach(generic => generic.Init(this));
    }

    private void FixedUpdate() {
        updatables.ForEach(updatable => updatable.ManualUpdate());
    }
}

public interface IGenericBootable {
    public void Init(Boot boot);
}

public interface IUpdatable {
    public void ManualUpdate();
}
