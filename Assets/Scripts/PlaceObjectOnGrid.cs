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
    public GameObject anth;
   
    [SerializeField] private List<Color> colors;
    [SerializeField] private List<GameObject> instancedTiles;
    [SerializeField] public GameObject prefab;
    Dictionary<Vector3Int, GameObject> someDictionary;
   


    void Start()
    {
       
        someDictionary = new Dictionary<Vector3Int, GameObject>();
        CreateGrid();
       
    }

    void Update()
    {
        RandomPosition();
        Compare();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Vector3 buf = new Vector3(smth.ramka.transform.position.x, 0.01f, smth.ramka.transform.position.z);
            Vector3Int els_buf = Vector3Int.RoundToInt(buf);
            someDictionary[els_buf].GetComponent<tile_col>().tilesColliderObject.SetActive(false);
            someDictionary[els_buf].GetComponent<Rigidbody>().AddForce(new Vector3(0, 350, 0));
            someDictionary[els_buf].transform.parent = smth.ramka.transform;
            anth = someDictionary[els_buf];


        }
    }


    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        GameObject instantiatedRamka = Instantiate(prefab, new Vector3(1, 0.002f, 1), Quaternion.identity);
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
                instancedTiles.Add(Instantiate(tile, new Vector3(i, 0.015f, j), Quaternion.identity));
                instancedTiles[num].GetComponent<Renderer>().material.color = colors[num];
                instancedTiles[num].GetComponent<tile_col>().border = this;
                someDictionary.Add(Vector3Int.RoundToInt(instancedTiles[num].transform.position), instancedTiles[num]);

                num++;
           

            }
        }
    }

    public void Record(GameObject tile_new)
    {

        someDictionary.Remove(Vector3Int.RoundToInt(tile_new.transform.position));
        someDictionary.Add(Vector3Int.RoundToInt(tile_new.transform.position), tile_new);

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

                        instancedTiles[num_2].transform.position = new Vector3(Random.Range(0, height), 0.015f, Random.Range(0, width));

                        if (!someDictionary.ContainsKey(Vector3Int.RoundToInt(instancedTiles[num_2].transform.position)))
                        {
                            isRepeating = false;
                        }
                    } while (isRepeating);
                    someDictionary.Add(Vector3Int.RoundToInt(instancedTiles[num_2].transform.position), instancedTiles[num_2]);
                }
            }
        }
    }

    public void Compare()
    {
        bool isColorMatchesEverywhere = true;
        foreach (Vector3Int coords in someDictionary.Keys)
        {
                   
            Color cellColor = nodes[(int)coords.x, (int)coords.z].obj.GetComponent<Renderer>().material.color;
            Color tileColor = someDictionary[Vector3Int.RoundToInt(coords)].GetComponent<Renderer>().material.color;
            if (cellColor != tileColor)
            {
                isColorMatchesEverywhere = false;
            }

            
     


        }
        if (isColorMatchesEverywhere) 
        {
            Debug.Log("Все цвета совпали!");
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
