using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class On_button_click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void onClick()
    {
        Debug.Log("клик");
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
