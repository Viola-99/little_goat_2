using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_col : MonoBehaviour
{
   // [SerializeField] public GameObject tilesColliderObject;
    [HideInInspector] public PlaceObjectOnGrid border;
    private int num_2;
    [HideInInspector] public bool onAir;

    void OnCollisionEnter(Collision collision)
    {
        tile_col obj_padeniy;
        collision.gameObject.TryGetComponent<tile_col>(out obj_padeniy);
        if (obj_padeniy != null)
        {
            if (obj_padeniy.onAir == true)
		    {
                Debug.Log("GameOver!");
            }
        }
        else
        {
            if (onAir)
            {
                onAir = false;

                border.OnTileFall(gameObject);
            }
        }
    }
}