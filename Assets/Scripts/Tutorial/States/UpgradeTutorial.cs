using UnityEngine;


public class UpgradeTutorial : AbstractManager
{
    string s = "Move to the upgrade stand (left) and use select to upgrade your bag";
    public override void EnterState(GameStateManager obj)
    {
        obj.tutorialText.text = s;
    }

    public override void UpdateState(GameStateManager obj)
    {
        if (GameManager.instance.maxMouseInventory != 5)
        {
            obj.ChangeState(obj.leaveTutorial);
        }
    }
}