using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    public bool requested;
    public GameObject tavolo;
    public NavMeshAgent agent;
    public bool assignedMaid;
    public string piatto;
    public int tempoAttesa;
    public string sediaLibera;


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
        sediaLibera = "Sedia ("+ help +")";
        if (help <= 6)
        {
            Vector3 destination = GameObject.Find(sediaLibera).transform.position;
            agent.SetDestination(destination);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name==sediaLibera)
{
            int index = UnityEngine.Random.Range(0, Piatti.dizionarioPiatti.Count);
            piatto = Piatti.dizionarioPiatti.Keys.ElementAt(index);
            tempoAttesa = Piatti.dizionarioPiatti.Values.ElementAt(index);
            Debug.Log($"Voglio {piatto}");
        }
    }
}
