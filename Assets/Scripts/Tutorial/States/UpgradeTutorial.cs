using UnityEngine;


public class UpgradeTutorial : AbstractManager
{
    string s = "Sell an item, gain a point. Move to the purple spot behind the upgrade stand (left) and use your points to upgrade your bag";
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