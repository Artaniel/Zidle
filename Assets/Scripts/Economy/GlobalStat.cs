using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStat : MonoBehaviour
{
    public float value;
    public string statName;

    public void ChangeGlobalStat(float delta) {
        value += delta;
    }
}
