using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : ManualMonobehaviour
{
    private Character _character;

    public float incubation = 0; // [0..1]
    public float contamination = 0;

    public void Init(Boot boot, Character character) {
        Init(boot);
        _character = character;
    }

    public override void ManualFixedUpdate() {
        if (contamination == 0) return;
        incubation += contamination * _boot.economy.virus.incubationSpeed;
    }
}
