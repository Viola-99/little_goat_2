using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public GameObject tile;

    [SerializeField] public int height;
    [SerializeField] public int width;
    private Node[,] nodes;
    private int num = 0, num_2=0;
    private bool isGameStarted = false;
    public move smth;
    public Vector3 buf;
    public GameObject anth;
   
    [SerializeField] private List<Color> colors;
    [SerializeField] private List<GameObject> instancedTiles;
    [SerializeField] public GameObject prefab;
    Dictionary<Vector3, GameObject> someDictionary;
   


    void Start()
    {
       
        someDictionary = new Dictionary<Vector3, GameObject>();
        CreateGrid();
        //audio = GetComponent<AudioSource>();
    }

    /*   void OnCollisionEnter()
       {
           if (someDictionary[buf].gameObject.tag == "tile")
           {
               Debug.Log("Game Over!");
               // a rigidbody tagged as "Ball" hit the player
           }

       }*/
    void Update()
    {
        RandomPosition();
        Compare();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 buf = new Vector3(smth.ramka.transform.position.x, 0.01f, smth.ramka.transform.position.z);
            someDictionary[buf].GetComponent<tile_col>().tilesColliderObject.SetActive(false);
            someDictionary[buf].GetComponent<Rigidbody>().AddForce(new Vector3(0, 350, 0));
            someDictionary[buf].transform.parent = smth.ramka.transform;
            anth = someDictionary[buf];






        }
        else
        {


            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                anth.transform.parent = null;
            }
        }

    }


    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        GameObject instantiatedRamka = Instantiate(prefab, new Vector3(1, 0.02f, 1), Quaternion.identity);
        smth.ramka = instantiatedRamka;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i, 0, j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell" + name;
                obj.GetComponent<Renderer>().material.color = colors[num];
                nodes[i, j] = new Node(true, worldPosition, obj);
                name++;
                instancedTiles.Add(Instantiate(tile, new Vector3(i, 0.01f, j), Quaternion.identity));
                instancedTiles[num].GetComponent<Renderer>().material.color = colors[num];
                someDictionary.Add(instancedTiles[num].transform.position, instancedTiles[num]);
                //anth_2 = someDictionary[num];
                num++;

            }
        }
    }

    private void RandomPosition()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGameStarted == false)
            {
                isGameStarted = true;
                someDictionary.Clear();

                for (num_2 = 0; num_2 < instancedTiles.Count; num_2++)
                {
                    bool isRepeating = true;
                    do
                    {
                        instancedTiles[num_2].transform.position = new Vector3(Random.Range(0, height), 0.01f, Random.Range(0, width));
                        if (!someDictionary.ContainsKey(instancedTiles[num_2].transform.position))
                        {
                            isRepeating = false;
                        }
                    } while (isRepeating);
                    someDictionary.Add(instancedTiles[num_2].transform.position, instancedTiles[num_2]);
                }
            }
        }
    }

    public void Compare()
    {
        bool isColorMatchesEverywhere = true;
        foreach (Vector3 coords in someDictionary.Keys)
        {
                   
            Color cellColor = nodes[(int)coords.x, (int)coords.z].obj.GetComponent<Renderer>().material.color;
            Color tileColor = someDictionary[coords].GetComponent<Renderer>().material.color;
            if (cellColor != tileColor)
            {
                isColorMatchesEverywhere = false;
            }
           
            Debug.Log("Color matches everywhere: " + isColorMatchesEverywhere);
        }
    }
    public class Node
    {
        public bool isPlaceable;
        public Vector3 cellPosition;
        public Transform obj;

        public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;
        }
    }
   
    }
