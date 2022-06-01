using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_col : MonoBehaviour
{
    [SerializeField] public GameObject tilesColliderObject;
    [HideInInspector] public PlaceObjectOnGrid border;
    private int num_2;
    void OnCollisionEnter(Collision collision)
    {
        if (!tilesColliderObject.activeSelf)
        {
            transform.parent = null;
            tilesColliderObject.SetActive(true);
            Debug.Log(border);
            border.Record(gameObject);


        }
  

    }


    void Start()
    {

    }

   
    void Update()
    {

    }
}