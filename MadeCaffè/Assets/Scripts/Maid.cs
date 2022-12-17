using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Maid : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject cliente = null;
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
        StartCoroutine(WaitForOrder());
    }

    private IEnumerator WaitForOrder()
    {
        yield return new WaitForSeconds(cliente.GetComponent<Cliente>().tempoAttesa);
        Debug.Log($"Preso ordine {cliente.GetComponent<Cliente>().piatto} di {cliente.name}");
    }
}
