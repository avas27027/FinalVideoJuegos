using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueletonController : MonoBehaviour
{
    public PlayerActions mPlayerActions;
    public State<SqueletonController> IdleState {get; private set;}
    public State<SqueletonController> GuardState { get; private set;}

    public StateMachine<SqueletonController> mSM = new StateMachine<SqueletonController>();
    // Start is called before the first frame update
    private void Awake()
    {
        mPlayerActions = new PlayerActions();
    }
    void Start()
    {
        IdleState = new IdleState(this, mSM);
        GuardState = new GuardState(this, mSM);
        mSM.Start(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        mSM.GetCurrentState().OnHandleInput();
        mSM.GetCurrentState().OnLogicUpdate();
    }

    private void FixedUpdate()
    {
        mSM.GetCurrentState().OnPhisicsUpdate();
    }
}
