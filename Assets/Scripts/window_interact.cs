using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_interact : MonoBehaviour
{
	private Doors_windows state;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F) /*&& enter*/)
		{
			Ray ray = new Ray(transform.position, Vector3.up);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				Open_Close();
			}

		}
	}
}
