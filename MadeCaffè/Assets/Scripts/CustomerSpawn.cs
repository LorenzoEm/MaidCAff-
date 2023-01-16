using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject CustomerPrefab;
    public int clienti;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(clienti));
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(CustomerPrefab, new Vector3(28, 1, -19), Quaternion.identity);
    }

    private IEnumerator Spawn(int times)
    {
        for(int n=0; n<times; n++)
        {
            Instantiate(CustomerPrefab, new Vector3(28, 1, -19), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
