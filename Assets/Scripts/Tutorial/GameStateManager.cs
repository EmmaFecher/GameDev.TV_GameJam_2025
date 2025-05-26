using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public AbstractManager currentState;
    public PlayingState playingState = new PlayingState();
    public GrabTutorial grabState = new GrabTutorial();
    public SellTutorial sellState = new SellTutorial();
    public UpgradeTutorial upgradeState = new UpgradeTutorial();
    public LeaveTutorial leaveTutorial = new LeaveTutorial();

    //Stuff the states need
    public PlayerMovement PM;
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialGrabObject;
    public void Start()
    {
        if (GameManager.instance.firstTime == true)
        {
            currentState = grabState;
        }
        else
        {
            currentState = playingState;
        }
        currentState.EnterState(this);
    }
    void Update()
    {
        if(currentState != null)
            currentState.UpdateState(this);
    }
    public void ChangeState(AbstractManager newState)
    {
        Debug.Log("entering state: "+newState);
        currentState = newState;
        currentState.EnterState(this);
        
    }
}