using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour
{
	[SerializeField] private GameObject letter_pick;
	private AudioSource _pickedLetter;
	[SerializeField] private GameObject Dialogues;
	public bool inInventory = false;

	// Start is called before the first frame update
	void Start()
    {
		Dialogues.SetActive(false);
		_pickedLetter = GetComponent<AudioSource>();
	}
     public void Destroy_letter()
	{
		
		Debug.Log("Picked!");
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
		RaycastHit hitData;
	


		if (Physics.Raycast(ray, out hitData))
		{
			if (hitData.transform.CompareTag("PickUp"))
			{
				if (!_pickedLetter.isPlaying)
				{
					_pickedLetter.Play();
				}
			
			Destroy(hitData.transform.gameObject);
			Dialogues.SetActive(true);
				inInventory = true;
			}
		}

	}

	// Update is called once per frame
	void Update()
    {
	if (Input.GetMouseButtonDown(0))
	{
			Destroy_letter();
	}
		if (Input.GetKeyDown(KeyCode.E) && inInventory==true)
		{
			
			
			_pickedLetter.Play();
			Dialogues.SetActive(false);
		//	inInventory = false;
		}

	}


}
