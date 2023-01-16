using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    public string ordine;
    private int tentativi = 0;
    public List<GameObject> posti;
    public NavMeshAgent agent;
    public bool ordinato;
    public bool servito;
    // Start is called before the first frame update
    void Start()
    {
        ordine = Piatti.dizionarioPiatti.ElementAt(Random.Range(0, Piatti.dizionarioPiatti.Count)).Key;
        posti.AddRange(GameObject.FindGameObjectsWithTag("Sedia"));
        agent.SetDestination(new Vector3(16, 1, -18));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        int rand = Random.Range(0, posti.Count);
        if (other.CompareTag("gate"))
        {
            do
            {
                rand = Random.Range(0, posti.Count);
                agent.SetDestination(posti[rand].transform.position);
                tentativi++;
            } while (posti[rand].GetComponent<Sedia>().prenotata != false && tentativi<6);
            if (tentativi < 6)
            {
                posti[rand].GetComponent<Sedia>().prenotata = true;
                posti[rand].GetComponent<Sedia>().cliente = gameObject;
            }
            else
            {
                agent.SetDestination(new Vector3(30, 0, -22));
                StartCoroutine(DestroyCustomer());
            }
        }
        if (other.CompareTag("Sedia"))
        {
            other.GetComponent<Sedia>().occupata = true;
        }
    }

    private IEnumerator DestroyCustomer()
    {
        yield return new WaitForSeconds(0);
        Destroy(gameObject,3);
        Debug.Log("scassato");
    }
}
