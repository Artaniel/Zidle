using UnityEngine;

public class IdleState : StateBase
{

    public override void Init() { }
    public override void StateUpdate() { }
    public override void StartState(Character owner, Boot boot) { base.StartState(owner, boot); }

}
