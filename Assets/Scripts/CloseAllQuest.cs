using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloseAllQuest : MonoBehaviour
{
    private bool isQuestCompleted = false;
    [SerializeField] private List<Doors_windows> doorsWindows;
     [SerializeField] private GameObject Quest_text;
    private In_out_home colid;
    //[SerializeField] private GameObject In_Out;
    //  private bool enter = true;
    // private TextMeshPro sometext;
    private void Start()
    {
        Quest_text.GetComponent<TextMeshProUGUI>().text = "Close all windows and the door";
        //Quest_text.sometext = Quest_text.GetComponent<TextMeshPro>();
        //sometext.text = "Close all windows and door";
        foreach (var elem in doorsWindows)
        {
            elem.OnOpen += OnOpen;
            elem.OnClose += OnClose;
        }
    }

    private void OnDestroy()
    {
        foreach (var elem in doorsWindows)
        {
            elem.OnOpen -= OnOpen;
            elem.OnClose -= OnClose;
        }
    }

    private void OnOpen()
    {
        //Debug.Log("Open");
    }

    private void OnClose()
    {
        //Debug.Log("Close");
     //   colid = GameObject.Find('').GetComponent<In_out_home>();
        if(!isQuestCompleted)
        {
            if (AreAllClosedCheck())
            {
                isQuestCompleted = true;
                foreach (var elem in doorsWindows)
                {
                    elem.OnOpen -= OnOpen;
                    elem.OnClose -= OnClose;
                }
                //  Quest_text.GetComponent<TextMeshPro>().text = "Quest Completed!";

                Quest_text.GetComponent<TextMeshProUGUI>().text = "Quest Completed";

                Debug.Log("Quest Completed!");
            }
           
        }
    }


    private bool AreAllClosedCheck()
    {
        foreach (var elem in doorsWindows)
        {
            if(elem.IsOpen)
            {
                return false;
             
            }
        }
        return true;
    }
}