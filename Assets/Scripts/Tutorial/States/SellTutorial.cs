using UnityEngine;


public class SellTutorial : AbstractManager
{
    string s = "Move to the purple spot behind the shop stand (right) and use select to fill the shop";
    public override void EnterState(GameStateManager obj)
    {
        obj.tutorialText.text = s;
    }

    public override void UpdateState(GameStateManager obj)
    {
        if (GameManager.instance.currentMouseInventory == 0)
        {
            obj.ChangeState(obj.upgradeState);
        }
    }
}