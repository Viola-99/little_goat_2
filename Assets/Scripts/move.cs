using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject ramka;//здесь ми указываем персонажа как игровой Object;
    [SerializeField] private PlaceObjectOnGrid border;
    public bool isGrounded;
    //public float TileToJump;
    


    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log(ramka.transform.position);
        //  ramka = (GameObject)this.gameObject; //тут присваиваем персонажа к игровому Object или как-то так.

    }
    private void OnCollisionEnter()
    {
        isGrounded = true;


    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //ramka.transform.position += ramka.transform.forward * speed * Time.deltaTime;
            if (ramka.transform.position.z < (border.height-1.0f))
            {
                ramka.transform.position += new Vector3(0f, 0f, 1f);
               // Debug.Log(ramka.transform.position);
                //Debug.Log("Нажато W");
            }

        }
        if (ramka.transform.position.z > 0 )
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ramka.transform.position -= new Vector3(0f, 0f, 1f);
               // Debug.Log("Нажато S");
            }
        }

        if (ramka.transform.position.x <= (border.width-2))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ramka.transform.position += new Vector3(1f, 0f, 0f);
               // Debug.Log("Нажато D");
            }
        }

        if (ramka.transform.position.x > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ramka.transform.position -= new Vector3(1f, 0f, 0f);
              //  Debug.Log("Нажато А");
            }                                              //всё легко и просто, как борщ(всё как Вы и просили)

        }
    /*    if (Input.GetKeyDown(KeyCode.Space ) && isGrounded==true) {
            
           isGrounded = false;
            border.tile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }
    */
    }

}
