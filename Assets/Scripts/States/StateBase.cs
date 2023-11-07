using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public Character owner;
    public abstract void StateUpdate();
    public abstract void Init(HumanFactory humanFactory);
}
