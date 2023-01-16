using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Maid : MonoBehaviour
{
    public List<GameObject> sedie;
    public string ordine;
    public GameObject bancone;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        bancone = GameObject.Find("Bancone");
        sedie.AddRange(GameObject.FindGameObjectsWithTag("Sedia"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator countdownTakeOrder()
    {
        CheckTakeOrder();
        yield return new WaitForSeconds(5);
    }
    private IEnumerator countdownCheckBancone()
    {
        yield return new WaitForSeconds(5);
    }

    public void CheckTakeOrder()
    {
        foreach(GameObject sedia in sedie)
        {
            if (sedia.GetComponent<Sedia>().occupata && !sedia.GetComponent<Sedia>().cliente.GetComponent<Cliente>().ordinato)
            {
                agent.SetDestination(sedia.transform.position);
                if(Collision.Equals(sedia, gameObject))
                {
                    TakeOrder(sedia);
                }
            }
        }
    }

    public void TakeOrder(GameObject sedia)
    {
        ordine = sedia.GetComponent<Sedia>().cliente.GetComponent<Cliente>().ordine;
    }
}
