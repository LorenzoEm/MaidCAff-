using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    public GameObject tavolo;
    public NavMeshAgent agent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (tavolo.GetComponent<Tavolo>().clientiSeduti < 6)
        {
            SetDesTinationToFreeChair(agent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDesTinationToFreeChair(NavMeshAgent agent)
    {
        string freeChair = "Sedia ("+ tavolo.GetComponent<Tavolo>().clientiSeduti+1 +")";
        
        Debug.Log(this.tag);
        Vector3 destination = GameObject.Find(freeChair).transform.position;
        agent.SetDestination(destination);
    }
}
