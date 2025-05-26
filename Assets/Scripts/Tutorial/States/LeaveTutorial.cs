using UnityEngine;


public class LeaveTutorial : AbstractManager
{
    string s = "Great! Now, step on the platform next to the bridge to continue to the 1st level!";
    public override void EnterState(GameStateManager obj)
    {
        obj.tutorialText.text = s;
    }

    public override void UpdateState(GameStateManager obj)
    {
        if (obj.PM.fireInput == true)
        {
            GameManager.instance.firstTime = false;
            obj.ChangeState(obj.playingState);
        }
    }
}