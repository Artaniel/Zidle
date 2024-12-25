using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMonobehaviour : MonoBehaviour
{
    protected Boot _boot;
    public  void Init(Boot boot) {
        _boot = boot;
        Init();
    }

    public virtual void Init() { }
    public virtual void ManualUpdate() { }
}
