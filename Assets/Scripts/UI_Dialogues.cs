using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dialogues : MonoBehaviour
{
    [SerializeField] private GameObject Dialogues;
    private string text;
    [SerializeField] private AudioSource TextSound;
    void Start()
    {
        text = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        StartCoroutine(TextCoroutine());

        Dialogues.SetActive(true);
            

    }

    IEnumerator TextCoroutine() {
      
        foreach (char abc in text) {
            GetComponent<Text>().text += abc;
            yield return new WaitForSeconds(0.05f);
            
        }
    
    }
    void Update()
    {
      
    }
}
