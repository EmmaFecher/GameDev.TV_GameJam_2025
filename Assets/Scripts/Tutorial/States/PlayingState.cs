using UnityEngine;


public class PlayingState : AbstractManager
{
    public override void EnterState(GameStateManager obj)
    {
        obj.tutorialPanel.SetActive(false);
        obj.tutorialGrabObject.SetActive(false);
    }

    public override void UpdateState(GameStateManager obj)
    {
        
    }
}