using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Maid : MonoBehaviour
{
    public GameObject tavolo;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tavolo = GameObject.FindGameObjectWithTag("Tavolino");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeOrder(Vector3 dest)
    {
        agent.SetDestination(dest);
    }
}
