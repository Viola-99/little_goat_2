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
    [SerializeField] private In_out_home colid;
    [SerializeField] private pick_up brought;

    //[SerializeField] private GameObject In_Out;
    //  private bool enter = true;
    // private TextMeshPro sometext;
    private void Start()
    {
       Quest_text.SetActive(false);
        Quest_text.GetComponent<TextMeshProUGUI>().text = "Close all windows and the door";
       
        foreach (var elem in doorsWindows)
        {
            elem.OnOpen += OnOpen;
            elem.OnClose += OnClose;
        }
    }
    private void TakeTask()
    {
        if (Input.GetKeyDown(KeyCode.E) && brought.inInventory == true) {
            Quest_text.SetActive(true);
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
        
    }

    private void OnClose()
    {
 
        if(!isQuestCompleted)
        {
            if (AreAllClosedCheck() && colid.enter)
            {
                isQuestCompleted = true;
                foreach (var elem in doorsWindows)
                {
                    elem.OnOpen -= OnOpen;
                    elem.OnClose -= OnClose;
                }
             
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

    void Update() {
        TakeTask();
    }
}