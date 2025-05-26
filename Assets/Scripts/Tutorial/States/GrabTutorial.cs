using UnityEngine;


public class GrabTutorial : AbstractManager
{
    public string s = "Move to the glowing yellow square, and use select ('E' or mouse click) to pick it up";
    public override void EnterState(GameStateManager obj)
    {
        obj.tutorialText.text = s;
    }

    public override void UpdateState(GameStateManager obj)
    {
        if (obj.tutorialGrabObject.GetComponent<ItemGrab>().grabbed == true)
        {
            obj.tutorialGrabObject.SetActive(false);
            obj.ChangeState(obj.sellState);
        }
    }
}