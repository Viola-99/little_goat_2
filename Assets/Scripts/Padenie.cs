using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padenie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("1");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
