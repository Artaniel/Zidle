using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgStat : MonoBehaviour
{
    public StatType statType;
}

public enum StatType
{
    IncubationSpeed,
    MinimalInfectionAmmount,
    AirborneTransitionSpeed,
    BloodborneTransitionSpeed,
    BiteTransitionChance,
    BiteTransitionAmmount,
    DeadRiseChancePerAmmount,
    CombatAttack,
    CombatDefence,
    CombatRegeneration
}
