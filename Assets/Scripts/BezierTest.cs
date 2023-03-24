using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class BezierTest : MonoBehaviour
{

    public Transform P0;
    public Transform P1;
    public Transform P2;
    public Transform P3;
    public int width;

   public GameObject prefab;
    [Range(0,1)]
    public float t;
    GameObject Fence_Prefab;

    void Start()
  {
    for (float f = 0; f <= 1; f+=0.1f)
        {
            Fence_Prefab = Instantiate(prefab, transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, f), Quaternion.identity);

            Fence_Prefab.transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, f));
            // i++;
        }
    }

    void Update()
    {


        //   Instantiate(prefab, Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t), Quaternion.identity);

        //Instantiate(prefab, transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t), Quaternion.identity);
       // transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));
    }


    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = P0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
             // Instantiate(prefab, P0.position, Quaternion.identity);
        }

    }

}
