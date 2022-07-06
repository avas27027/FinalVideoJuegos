using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : State<SqueletonController>
{
    
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
        mController.SetTrigerCol(false);
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
        
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();

        mController.GetComponent<CircleCollider2D>().radius = mController.hitBox;
        if (mController.GetTrigerCol())
        {
            
            mSM.ChangeState(mController.AttackState);
        }

    }

    

    public override void OnPhisicsUpdate()
    {
        base.OnPhisicsUpdate();
    }

}
