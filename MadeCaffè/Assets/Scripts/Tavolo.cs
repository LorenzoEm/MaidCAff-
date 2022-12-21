using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Tavolo : MonoBehaviour
{
    public int clientiSeduti;
    public List<GameObject> clienti;
    public List<GameObject> maids;
    public int index=0;

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
        if (other.CompareTag("Cliente"))
        {
            other.gameObject.GetComponent<Cliente>().SetDesTinationToFreeChair(other.gameObject.GetComponent<NavMeshAgent>());
            clienti.Add(other.gameObject);
            clientiSeduti++;
            StartCoroutine(CallMaid(other.gameObject));
            Debug.Log("Attesa");
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
    private IEnumerator CallMaid(GameObject client)
    {
        GameObject selectedMaid;
        if (index < maids.Count)
        {
            selectedMaid = maids[index];
            selectedMaid.GetComponent<Maid>().cliente = client;
            index++;
            yield return new WaitForSeconds(3);
            selectedMaid.GetComponent<Maid>().TakeOrder();
        }
    }

}
