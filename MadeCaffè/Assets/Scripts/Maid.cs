using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Maid : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject cliente = null;
    public string ordine = "";
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeOrder()
    {
        agent.SetDestination(cliente.transform.position);
        if (ordine!="")
        {
            GetOrder();
        }
    }

    private void GetOrder()
    {
        Debug.Log($"Preso ordine {cliente.GetComponent<Cliente>().piatto} di {cliente.name}");
        ordine = cliente.GetComponent<Cliente>().piatto;
        Debug.Log("Preso ordine");
        if(ordine!="")
        ReturnToDesk();
    }

    public void ReturnToDesk()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Bancone").transform.position);
        Debug.Log("Famme sto coso");
    }
}
