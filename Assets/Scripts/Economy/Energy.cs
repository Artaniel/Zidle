using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : EconomyResource
{
    public static Energy Instantiate(ResoursePrototype prototype) {
        Energy result = (Energy)prototype.Instantiate();
        return result;
    }
}
