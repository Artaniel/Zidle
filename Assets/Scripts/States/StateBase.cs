using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    protected Character owner;
    public abstract void StateUpdate();
    public abstract void Init();
    public virtual void StartState(Character _owner) {
        owner = _owner;
    }
}
