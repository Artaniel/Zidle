using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : ManualMonobehaviour
{
    public float incubationSpeed = 0.01f;
    private float defaultIncubationSpeed;
    public List<EvolutionPerk> activePerks;

    public override void Init() {
        defaultIncubationSpeed = incubationSpeed;
    }

    public override void ManualFixedUpdate() {
        
    }

    public void RefreshStatsFromPerks() { 
        
    }
}
