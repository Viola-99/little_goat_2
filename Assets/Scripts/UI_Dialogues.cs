using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dialogues : MonoBehaviour
{
    [SerializeField] private GameObject Dialogues;
    private bool isGameStarted = false;
   // private float tick = 0;
    private IEnumerator TextDelay;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Dialogues.SetActive(false);
        yield return new WaitForSeconds(5);
        Dialogues.SetActive(true);
      //  yield return new WaitForSeconds(5);
      //Dialogues.SetActive(false);
        

    }

  /* IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
    }*/
    // Update is called once per frame
    void Update()
    {
        if (isGameStarted == true) {
            Dialogues.SetActive(true);
        }
    }
}
