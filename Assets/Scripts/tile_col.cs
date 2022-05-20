using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tile_col : MonoBehaviour
{
    [SerializeField] public GameObject tilesColliderObject;
    private PlaceObjectOnGrid control;
    // Start is called before the first frame update
    private int num_2 = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (!tilesColliderObject.activeSelf)
        {
           transform.parent = null;
            Debug.Log("Unparenting");
            tilesColliderObject.SetActive(true);
            control.someDictionary.Remove(control.instancedTiles[num_2].transform.position);
            control.someDictionary.Add(control.instancedTiles[num_2].transform.position, control.instancedTiles[num_2]);
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
