using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour
{
	[SerializeField] private GameObject letter_pick;
	// Start is called before the first frame update
	void Start()
    {
        
    }
     public void Destroy_letter()
	{
		
			Debug.Log("Button F clicked!");
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hitData;
	


		if (Physics.Raycast(ray, out hitData))
		{
			Destroy(letter_pick);// The Ray hit something!
		}

	}

	// Update is called once per frame
	void Update()
    {
	if (Input.GetKeyDown(KeyCode.F))
	{
			Destroy_letter();
	}


	}


}
