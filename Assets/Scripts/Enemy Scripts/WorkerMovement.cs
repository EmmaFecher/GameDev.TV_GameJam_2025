using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WorkerMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private NavMeshAgent NMA;
    public int currentWay = 0;

    public Transform player;
    public bool inRange = false;
    public float rangeDistance = 6f;

    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        NMA.SetDestination(waypoints[currentWay].position);
    }

    void Update()
    {
        if (inRange)
        {
            NMA.SetDestination(player.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[currentWay].position) < 1f)
            {
                currentWay++;
                if (currentWay > waypoints.Length - 1)
                {
                    currentWay = 0;
                }
            }
            NMA.SetDestination(waypoints[currentWay].position);
        }
        float dis = Vector3.Distance(transform.position, player.position);
        if (dis > rangeDistance)
        {
            inRange = false;
        }
        else
        {
            inRange = true;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("/GameCanvas").GetComponent<GameUI>().GameOver();
        }
    }
}
