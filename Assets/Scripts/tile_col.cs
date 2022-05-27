using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_col : MonoBehaviour
{
    [SerializeField] public GameObject tilesColliderObject;
    // Start is called before the first frame update
    [SerializeField] public PlaceObjectOnGrid border;
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
       // Debug.Log(tilesColliderObject);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}