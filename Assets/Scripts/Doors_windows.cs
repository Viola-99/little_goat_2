using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doors_windows : MonoBehaviour
{
	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	public AudioClip OpenAudio;
	public AudioClip CloseAudio;

	private Vector3 defaultRot;
	private Vector3 openRot;
	[SerializeField] private bool isOpen;
	private bool enter;
	[SerializeField] private GameObject InteractionDescriptionText;

	public bool IsOpen => isOpen;
	public event Action OnOpen;
	public event Action OnClose;

	void Start()
	{
		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
		if(isOpen)
        {
			transform.eulerAngles = openRot;
		}
		else
        {
			transform.eulerAngles = defaultRot;
        }
		
		InteractionDescriptionText.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && enter)
		{
			isOpen = !isOpen;
			if(isOpen == true)
            {
				gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
				OnOpen?.Invoke();
			}
			else
            {
				gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
				OnClose?.Invoke();
			}
		}
		if (isOpen)
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}
		else
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		InteractionDescriptionText.SetActive(true);
		if (col.tag == "Character")
		{
			enter = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		InteractionDescriptionText.SetActive(false);
		if (col.tag == "Character")
		{
			enter = false;
		}
	}
}