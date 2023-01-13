using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavolo : MonoBehaviour
{
    public List<GameObject> posti;
    // Start is called before the first frame update
    void Start()
    {
        posti.AddRange(GameObject.FindGameObjectsWithTag("Sedia"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
