using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public enum state
{
    walking,
    idle,
    buying,
    bought,
    leave
}
public class MouseCustomer : MonoBehaviour
{
    public List<Transform> ways;
    public GameObject waypointsParent;
    private NavMeshAgent NMA;
    public int currentWay = 0;
    public bool atDesk = false;
    bool firstBuy = true;
    bool firstBought = true;
    public state currentState;
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        currentState = state.walking;
        for (int i = 0; i < waypointsParent.transform.childCount; i++)
        {
            ways.Add(waypointsParent.transform.GetChild(i));
        }

        NMA.SetDestination(ways[currentWay].position);
    }
    void Update()
    {
        switch (currentState)
        {
            case state.walking:
                //walking anim
                if (Vector3.Distance(transform.position, ways[currentWay].position) < 1f)
                {
                    if (currentWay >= ways.Count - 1)
                    {
                        atDesk = true;
                        currentState = state.idle;
                    }
                    else
                    {
                        currentWay++;
                    }
                }
                if (!atDesk)
                {
                    NMA.SetDestination(ways[currentWay].position);
                }
                break;
            case state.idle:
                //idle anim
                NMA.ResetPath();
                if (GameManager.instance.shopInventory > 0)
                {
                    currentState = state.buying;
                }
                break;
            case state.buying:
                //buying anim, and possibly courutine
                if (firstBuy)
                {
                    StartCoroutine(Buy());
                    firstBuy = false;
                }
                break;
            case state.bought:
                //bought anim
                if (firstBought)
                {
                    StartCoroutine(Bought());
                    firstBought = false;
                }

                if (NMA.destination != null)
                {
                    //moving
                    //at end of list, destry
                }
                    break;
            default:
                NMA.SetDestination(ways[0].position);
                if (Vector3.Distance(transform.position, ways[0].position) < 1f)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }
    IEnumerator Buy()
    {
        yield return new WaitForSeconds(3);
        currentState = state.bought;
        GameManager.instance.UpdateShopInventory(-1);
        GameManager.instance.score++;
        GameObject.Find("/GameCanvas").GetComponent<GameUI>().UpdateBackpack();
    }
    IEnumerator Bought()
    {
        //wait
        yield return new WaitForSeconds(3);

        //set path
        currentState = state.leave;
    }
}
