using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<SqueletonController>
{
    private float mTimer = 0f;
    private float v = 0;
    public AttackState(SqueletonController mController, StateMachine<SqueletonController> mSM) : base(mController, mSM)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entrando al AttackState");
        v = 0;
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        
        mTimer += Time.deltaTime;
        if(mTimer > mController.tiempoDisparo)
        {
            v = Vector2.Distance(mController.transform.position, mController.objColTra.position);   
            mController.Disparar();
            mTimer = 0f;
            
            Debug.Log(v);
        }
        
        if(v > mController.hitBox)
        {
            Debug.Log("Salida : "+v);
            //Debug.Log("Actual "+mController.objColAct);
            //Debug.Log("Previo " + mController.objColPrev);
            mSM.ChangeState(mController.GuardState);
        }
        
        
        
    }

    public override void OnExit()
    {
        base.OnExit();
        //mController.objColTra = null;
    }

    public override void OnPhisicsUpdate()
    {
        base.OnPhisicsUpdate();
    }
}
