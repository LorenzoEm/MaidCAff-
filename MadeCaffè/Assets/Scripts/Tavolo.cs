using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavolo : MonoBehaviour
{
    public int clientiSeduti;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Porco dio");
        if (other.tag == "pippo")
        {

            clientiSeduti++;
        }

    }




    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("pippo"))
    //    {
    //        clientiSeduti--;
    //    }
    //}
}
