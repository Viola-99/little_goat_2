using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_interact : MonoBehaviour
{

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F) )
		{

			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				//Open_Close();
				Doors_windows doorsWindows;
				if (hit.transform.TryGetComponent<Doors_windows>(out doorsWindows)) {
					doorsWindows.Open_Close();
				}
			}

		}
	}
}
