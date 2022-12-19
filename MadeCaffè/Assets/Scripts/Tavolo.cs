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
    public int index;

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
            index = Random.Range(0, Piatti.dizionarioPiatti.Count);
            other.GetComponent<Cliente>().piatto = Piatti.dizionarioPiatti.Keys.ElementAt(index);
            other.GetComponent<Cliente>().tempoAttesa = Piatti.dizionarioPiatti.Values.ElementAt(index);
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
    private IEnumerator CallMaid(GameObject cliente)
    {
        yield return new WaitForSeconds(3);
        GameObject maidRandom = maids[Random.Range(0,maids.Count)];
        maidRandom.GetComponent<Maid>().cliente = cliente;
        maidRandom.GetComponent<Maid>().TakeOrder();
    }

}
