using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    protected Character _owner;
    protected Boot _boot;

    public abstract void StateUpdate();
    public abstract void Init();
    public virtual void StartState(Character owner, Boot boot) {
        _owner = owner;
        _boot = boot;
    }
}
