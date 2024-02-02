using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int a = 0;
    private int b = 1;
    private int c = 0;
    private const int max = 1000;
    void Start()
    {
        Debug.Log("Hello world!");
    }

    void Update()
    {
        c = a + b;
        a = b;
        b = c;
        if(c >= max) {
            Destroy(this);
            return;
        }
        Debug.Log(c);
    }
}
