using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piatti : MonoBehaviour
{
    public static Dictionary<string, int> dizionarioPiatti = new Dictionary<string, int>()
    {
        { "sandwich", 7},
        { "curry", 10},
        { "nomurice",12},
        { "torta", 6},
        { "gelato", 7},
        { "caffe", 3},
        { "te", 3},
        { "bevande", 3},
        { "milkshake", 5},
        { "biscotti", 2}
    };
}
