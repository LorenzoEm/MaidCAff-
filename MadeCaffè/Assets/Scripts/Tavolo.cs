using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tavolo : MonoBehaviour
{
    public int clientiSeduti;
    public List<GameObject> clienti;
    public List<GameObject> maids;

    private void Start()
    {
        GameObject[] help = GameObject.FindGameObjectsWithTag("Maid");
        foreach(GameObject go in help)
        {
            maids.Add(go);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cliente")
        {
            other.gameObject.GetComponent<Cliente>().SetDesTinationToFreeChair(other.gameObject.GetComponent<NavMeshAgent>());
            clienti.Add(other.gameObject);
            clientiSeduti++;
            StartCoroutine(CallMaid());
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pippo"))
        {
            clienti.Remove(other.gameObject);
            clientiSeduti--;
        }
    }
    private IEnumerator CallMaid()
    {
        Vector3 dest = new Vector3(0,0,0);
        yield return new WaitForSeconds(3);
        int random = Random.Range(0, clienti.Count);
        while (dest != Vector3(0,0,0))
        {
            if (!clienti[random].GetComponent<Cliente>().assignedMaid)
            {
                dest = clienti[random].transform.position;
            }
        }
        maids[Random.Range(0,3)].GetComponent<Maid>().TakeOrder(dest);
    }
}
