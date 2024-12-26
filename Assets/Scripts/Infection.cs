using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    private Boot _boot;
    private Character _character;

    public float incubation = 0; // [0..1]


    public void Init(Boot boot, Character character) {
        _boot = boot;
        _character = character;
    }
}
