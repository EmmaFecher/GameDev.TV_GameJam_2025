using UnityEngine;


public class LeaveTutorial : AbstractManager
{
    string s = "Great! Now, step on the platform next to the bridge and steal everything! Watch for employees though.";
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