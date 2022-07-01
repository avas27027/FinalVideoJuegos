using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : State<SqueletonController>
{
    public float rotationSpeed;

    public GuardState(SqueletonController mController, StateMachine<SqueletonController> mSM) : base(mController, mSM)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entrando al GuardState");
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
    }

    public override void OnPhisicsUpdate()
    {
        base.OnPhisicsUpdate();
    }

}
