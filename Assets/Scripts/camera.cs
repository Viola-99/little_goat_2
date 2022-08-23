using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
    {
    [SerializeField] private PlaceObjectOnGrid grid;
    [SerializeField] private GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(grid.width / 2, 8f, grid.height / 2);
        Vector3Int cam_pos = Vector3Int.RoundToInt(Camera.transform.position);
        Debug.Log(Camera.transform.position);
       if ((grid.height / 2) > 8 || (grid.width / 2) > 8)
{
Camera.transform.Rotate(0, 0, 90);
}
//if (grid.height >= 7 && grid.width >= 7)
//{
//Camera.transform.position = new Vector3(grid.width / 2, 15f, grid.height / 2);
//}
//else
//{
Camera.transform.position = new Vector3 (grid.nodes[0, 0].obj.transform.position.x + grid.nodes[grid.width - 1, grid.height - 1].obj.transform.position.x, 8f, grid.nodes[0, 0].obj.transform.position.z + grid.nodes[grid.width - 1, grid.height - 1].obj.transform.position.z);
//}
       
        
    }
}
