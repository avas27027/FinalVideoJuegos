using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<HeroController>
{
    public IdleState(HeroController mController, StateMachine<HeroController> mSM) : base(mController, mSM)
    {
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
