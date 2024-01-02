using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStat
{
    public float value;
    public string statName;

    public GlobalStat(float defaultValue) {
        value = defaultValue;
    }

    public void Change(float delta) {
        value += delta;
    }
}
