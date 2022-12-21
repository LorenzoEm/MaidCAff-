using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Maid : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject cliente = null;
    public string ordine = "";
    public string piattoInMano = "";
    private bool continueFlag;
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
        if (ordine=="")
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

    public void GetDish()
    {
        StartCoroutine(Attesa(cliente.GetComponent<Cliente>().tempoAttesa));
        while (!continueFlag)
        {
            continue;
        }
        piattoInMano = cliente.GetComponent<Cliente>().piatto;
        agent.SetDestination(cliente.transform.position);
    }

    private IEnumerator Attesa(int s)
    {
        continueFlag = false;
        yield return new WaitForSeconds(s);
        continueFlag = true;
    }
}
