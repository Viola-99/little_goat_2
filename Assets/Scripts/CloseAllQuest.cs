using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAllQuest : MonoBehaviour
{
    private bool isQuestCompleted = false;
    [SerializeField] private List<Doors_windows> doorsWindows;

    private void Start()
    {
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
        if(!isQuestCompleted)
        {
            if(AreAllClosedCheck())
            {
                isQuestCompleted = true;
                foreach (var elem in doorsWindows)
                {
                    elem.OnOpen -= OnOpen;
                    elem.OnClose -= OnClose;
                }

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