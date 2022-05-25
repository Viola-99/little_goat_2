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
<<<<<<< HEAD
            Debug.Log(border);
            border.Record(gameObject);
=======
            Debug.Log(tilesColliderObject);

>>>>>>> 3de5a74e1ef8da6a5a392dd8a502e8c6d4868242
        }
        Debug.Log(tilesColliderObject);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}