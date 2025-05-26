using UnityEngine;

public abstract class AbstractManager
{
    public abstract void EnterState(GameStateManager obj);
    public abstract void UpdateState(GameStateManager obj);
}