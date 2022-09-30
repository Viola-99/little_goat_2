using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Dialogues : MonoBehaviour
{
    private AudioManager audioManager;
    private TextMeshProUGUI targetTextComponent;
    [SerializeField] private GameObject Dialogues;
    //[SerializeField] private AudioSource TextSound;

    [SerializeField] private float oneCharacterDelay = 0.5f;
    [SerializeField] private float additionalSentenceEndDelay = 0.2f;
    [SerializeField] [TextArea(5, 10)] private string introText;

    private delegate void Callback();

    IEnumerator TextCoroutine() 
    {
        foreach (char abc in introText) 
        {
            GetComponent<Text>().text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Start()
    {
        //text = GetComponent<Text>().text;
        //GetComponent<Text>().text = "";
        //StartCoroutine(TextCoroutine());

        //Dialogues.SetActive(true);

        audioManager = FindObjectOfType<AudioManager>();
        targetTextComponent = GetComponent<TextMeshProUGUI>();

        Dialogues.SetActive(true);
        StartCoroutine(Intro(1f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dialogues.SetActive(false);
            OnTypingEnd();
        }
    }
    
    IEnumerator Intro(float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        audioManager.Play("typingSound");
        audioManager.SetVolume("typingSound", 1f);

        StartCoroutine(TypeText(introText, OnTypingEnd));
        //yield return new WaitForSeconds(37f);

        //    audioManager.SetVolume("typingSound", 1f);

        // yield return new WaitForSeconds(2f);
        //  TextSound.Play(0);

        // audioManager.StartFade("ambient", "typingSound", 1f, 0f);
        // yield return new WaitForSeconds(2f);
        //load.SetActive(true);
        //yield return new WaitForSeconds(2f);
        //Cursor.visible = true;
    }

    IEnumerator TypeText(string fullText, Callback onTypingEnd = null)
    {
        string currentText;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            targetTextComponent.text = currentText;
            yield return new WaitForSeconds(oneCharacterDelay);
            if (currentText.EndsWith("."))
            {
                yield return new WaitForSeconds(oneCharacterDelay + additionalSentenceEndDelay);
            }
        }
        onTypingEnd?.Invoke();
    }

    private void OnTypingEnd()
    {
        audioManager.SetVolume("typingSound", 0f);
    }
}