using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyResource
{
    public float max = 1f;
    public float value = 0f;
    public float startingValue = 0f;
    public float regen = 0f;
    public string UIName = "placeholder";

    public virtual string GetUIString() {
        return $"{value:0.00}/{max} {UIName}";
    }

    public static EconomyResource Instantiate(ResoursePrototype prototype) {
        return prototype.Instantiate();
    }

    public void ApplyRegen() {
        Change(regen * Time.deltaTime);
    }

    public void Change(float ammount) {
        value = Mathf.Clamp(value + ammount, 0, max);
    }
}
