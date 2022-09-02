using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Dialogues : MonoBehaviour
{
    [SerializeField] private GameObject Dialogues;
    private string text;
    //[SerializeField] private AudioSource TextSound;
   /* void Start()
    {
        text = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        StartCoroutine(TextCoroutine());

        Dialogues.SetActive(true);
            

    }*/

    IEnumerator TextCoroutine() {
      
        foreach (char abc in text) {
            GetComponent<Text>().text += abc;
            yield return new WaitForSeconds(0.05f);
            
        }
    
    }
  /*  void Update()
    {
      
    }*/

    public float delay = 0.5f;
    private string currentText = "";
    //public GameObject load;

    private void Start()
    {
        Dialogues.SetActive(true);
         StartCoroutine(Intro());
        FindObjectOfType<AudioManager>().Play("typingSound");
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Dialogues.SetActive(false);
        }
    }
    
    IEnumerator Intro()
    {
        /// FindObjectOfType<AudioManager>().SetVolume("typingSound", 1f);
        // yield return new WaitForSeconds(1f);
       
         yield return new WaitForSeconds(1f);

        StartCoroutine(TypeText("\t Мама отправилась за лекарствами младшему брату сутки назад. Нужно закрыть все окна в доме, иначе брату станет хуже или придет волк. "));
        yield return new WaitForSeconds(37f);
        FindObjectOfType<AudioManager>().SetVolume("typingSound", 0f);
        //    FindObjectOfType<AudioManager>().SetVolume("typingSound", 1f);

        // yield return new WaitForSeconds(2f);
        //  TextSound.Play(0);


        // FindObjectOfType<AudioManager>().StartFade("ambient", "typingSound", 1f, 0f);
        // yield return new WaitForSeconds(2f);
        //load.SetActive(true);
        //yield return new WaitForSeconds(2f);
        //Cursor.visible = true;
        //    SceneManager.LoadScene("room");
    }

    IEnumerator TypeText(string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<TextMeshProUGUI>().text = currentText;
            FindObjectOfType<AudioManager>().Play("typingSound");
            yield return new WaitForSeconds(delay);
            if (currentText.EndsWith("."))
                yield return new WaitForSeconds(delay + 0.2f);
        }
    }

}
