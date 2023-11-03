using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public Character owner;
    public abstract void StateUpdate();
}
