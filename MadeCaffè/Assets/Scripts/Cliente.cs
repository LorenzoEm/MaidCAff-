using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    public bool requested;
    public GameObject tavolo;
    public NavMeshAgent agent;
    public bool assignedMaid;


    // Start is called before the first frame update
    void Start()
    {
        requested = false;
        tavolo = GameObject.FindGameObjectWithTag("Tavolino");
        agent.SetDestination(GameObject.Find("Tavolo").transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDesTinationToFreeChair(NavMeshAgent agent)
    {
        int help = tavolo.GetComponent<Tavolo>().clientiSeduti+1;
        string freeChair = "Sedia ("+ help +")";
        Vector3 destination = GameObject.Find(freeChair).transform.position;
        agent.SetDestination(destination);
    }
}
