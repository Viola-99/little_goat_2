using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tile_col : MonoBehaviour
{
    [SerializeField] public GameObject tilesColliderObject;
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        if (tilesColliderObject.activeSelf)
        {
            tilesColliderObject.SetActive(true);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
