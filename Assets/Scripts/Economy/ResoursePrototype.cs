using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResoursePrototype", menuName = "ScriptableObjects/ResoursePrototype", order = 1)]
public class ResoursePrototype : ScriptableObject
{
    public float max = 1f;
    public float startingValue = 0f;
    public float regen = 0f;
    public string UIName = "placeholder";

    public EconomyResource Instantiate() {
        EconomyResource result = new EconomyResource();
        result.max = max;
        result.startingValue = startingValue;
        result.regen = regen;
        result.UIName = UIName;

        return result;
    }
}
