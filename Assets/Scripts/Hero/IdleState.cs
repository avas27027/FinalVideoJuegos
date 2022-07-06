using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : State<SqueletonController>
{
    private bool SpacePressed = false;
    public IdleState(SqueletonController mController, StateMachine<SqueletonController> mSM) : base(mController, mSM)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entrando a IdleState");

        mController.mPlayerActions.Entradas.SpacePressed.performed += OnSpacePressed;
        mController.mPlayerActions.Enable();
    }

    private void OnSpacePressed(InputAction.CallbackContext obj)
    {
        SpacePressed = true;
    }


    public override void OnExit()
    {
        base.OnExit();
        SpacePressed = false;
    }

    public override void OnHandleInput()
    {
        base.OnHandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        if (SpacePressed)
        {
            mSM.ChangeState(mController.GuardState);
        }
    }

    public override void OnPhisicsUpdate()
    {
        base.OnPhisicsUpdate();
    }



}
