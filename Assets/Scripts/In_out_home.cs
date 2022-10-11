using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_out_home : MonoBehaviour
{
    public bool enter = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //InteractionDescriptionText.SetActive(true);
        if (col.tag == "Character")
        {
            enter = true;
            Debug.Log("Enter");
        }
    }

    void OnTriggerExit(Collider col)
    {
        //InteractionDescriptionText.SetActive(false);
        if (col.tag == "Character")
        {
            enter = false;
            Debug.Log("Exit");
        }
    }

}
