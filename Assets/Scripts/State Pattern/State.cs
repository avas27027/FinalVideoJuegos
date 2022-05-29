public abstract class State<T>
{
    protected T mController;
    protected StateMachine<T> mSM;

    public State(T mController, StateMachine<T> mSM)
    {
        this.mController = mController;
        this.mSM = mSM;
    }

    public void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnHandleInput() { }
    public virtual void OnLogicUpdate() { }
    public virtual void OnPhisicsUpdate() { }
}