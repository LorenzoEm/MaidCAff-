using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    public List<GameObject> posti;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("entrato");
            do
            {
                rand = Random.Range(0, posti.Count);
                agent.SetDestination(posti[rand].transform.position);
                Debug.Log($"vado a {posti[rand]}");
            } while (posti[rand].GetComponent<Sedia>().prenotata != false);
            posti[rand].GetComponent<Sedia>().prenotata = true;
        }
        if (other.CompareTag("Sedia"))
        {
            other.GetComponent<Sedia>().occupata = true;
        }
    }
}
