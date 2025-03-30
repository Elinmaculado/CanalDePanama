using UnityEngine;

public abstract class BS
{
    public abstract void EnterState(SM ship);
    public abstract void UpdateState(SM ship);
    public abstract void ExitState(SM ship);
}
