using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_windows : MonoBehaviour
{
	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	public AudioClip OpenAudio;
	public AudioClip CloseAudio;
	private bool AudioS;

	private Vector3 defaultRot;
	private Vector3 openRot;
	private bool open;
	private bool enter;
	[SerializeField] private GameObject Text;

	// Use this for initialization
	void Start()
	{

		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
		Text.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (open)
		{
			if (AudioS == false)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
				AudioS = true;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}
		else
		{
			if (AudioS == true)
			{
			gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
		AudioS = false;
		}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

		}
		if (Input.GetKeyDown(KeyCode.F) && enter)
		{
			open = !open;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		Text.SetActive(true);
		if (col.tag == "Character")
		{
			enter = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		Text.SetActive(false);
		if (col.tag == "Character")
		{
			enter = false;
		}
	}
}

