using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject CustomerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CustomerPrefab, new Vector3(28,1,-19), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
