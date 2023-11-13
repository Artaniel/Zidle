using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public Character owner;
    public abstract void StateUpdate();
    public abstract void Init();
    public abstract void StartState();
}
