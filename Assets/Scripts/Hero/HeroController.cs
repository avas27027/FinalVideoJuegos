using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public State<HeroController> IdleState {get; private set;}

    public StateMachine<HeroController> mSM = new StateMachine<HeroController>();
    // Start is called before the first frame update
    void Start()
    {
        IdleState = new IdleState(this, mSM);

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
