using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
    {
    [SerializeField] private PlaceObjectOnGrid grid;
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private GameObject cameraObject;
    [Space]
    [SerializeField] private float defaultCameraHeight = 8f;

    void Start()
    {
        Vector3 cameraPivotPosition = (grid.nodes[0, 0].obj.transform.position + grid.nodes[grid.width - 1, grid.height - 1].obj.transform.position) / 2;
        cameraPivot.transform.position = cameraPivotPosition;
        //Debug.Log(cameraPivot.transform.position);

        float cameraHeight = defaultCameraHeight;
        if (grid.height >= 8 && grid.width >= 8)
        {
            cameraHeight = 10f;
        }
        if (grid.height >= 12 && grid.width >= 12)
        {
            cameraHeight = 15f;
        }
        cameraObject.transform.localPosition = new Vector3(cameraObject.transform.localPosition.x, cameraHeight, cameraObject.transform.localPosition.x);
        //cameraObject.transform.LookAt(cameraPivot.transform);
    }
}
