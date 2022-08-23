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
    public Node[,] nodes;
    private bool isGameStarted = false;
    private bool isGameEnded = false;

    public SelectionOutlineControl selectionControl;
    public GameObject manipulatedTile;
   
    [SerializeField] private List<Color> colors;
    [SerializeField] private List<GameObject> instancedTiles;
    [SerializeField] public GameObject prefab;
    [SerializeField] public GameObject instantExtraTile;
    Dictionary<Vector3Int, GameObject> someDictionary;

    [SerializeField] private GameObject loseUIElement;
    [SerializeField] private GameObject winUIElement;
    [SerializeField] private GameObject menu_panel;
    [SerializeField] private GameObject win_panel;

    [SerializeField] private AudioSource testSound;

    void Start()
    {
        AddColor();
        CreateGrid();
        menu_panel.SetActive(false);
        win_panel.SetActive(false);
       }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGameStarted == false)
            {
                isGameStarted = true;
                RandomizeTilesPositions();
               
                instantExtraTile = Instantiate(tile, new Vector3(1, 2, 1), Quaternion.identity);
                instantExtraTile.GetComponent<Renderer>().material.color = Color.grey;
                instantExtraTile.GetComponent<tile_col>().border = this;
                instantExtraTile.GetComponent<tile_col>().onAir = true;
                instantExtraTile.transform.parent = selectionControl.ramka.transform;
            }
        }

        if(isGameStarted == true && isGameEnded == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                TileJump();
            }
            CompareColorsWinCheck();
        }
    }
    private void AddColor() {

        colors.Add(Color.blue);
        colors.Add(Color.black);
        colors.Add(Color.green);
        colors.Add(Color.red);
        colors.Add(Color.yellow);
        colors.Add(Color.white);
    }
	
	private void CreateGrid()
    {
        int num = 0;
        width = Random.Range(2, 10);
        height = Random.Range(2, 10);
        nodes = new Node[width, height];
        someDictionary = new Dictionary<Vector3Int, GameObject>();
        GameObject instantiatedRamka = Instantiate(prefab, new Vector3(1, 0.002f, 1), Quaternion.identity);
        selectionControl.ramka = instantiatedRamka;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //create cell
                Vector3 worldPosition = new Vector3(i, 0, j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell" + num;
                obj.GetComponent<Renderer>().material.color = colors [Random.Range(0, colors.Count)];

                nodes[i, j] = new Node(true, worldPosition, obj);
                

                //create tile
                instancedTiles.Add(Instantiate(tile, new Vector3(i, 0.015f, j), Quaternion.identity));
                instancedTiles[num].GetComponent<Renderer>().material.color = obj.GetComponent<Renderer>().material.color;
                instancedTiles[num].GetComponent<tile_col>().border = this;
                someDictionary.Add(Vector3Int.RoundToInt(instancedTiles[num].transform.position), instancedTiles[num]);

                num++;
            }
        }
    }

    private void TileJump()
    {
        Vector3Int els_buf = Vector3Int.RoundToInt(selectionControl.ramka.transform.position);
        els_buf.y = 0;

        if (someDictionary[els_buf] != null)
        {
            if(manipulatedTile != null)
            {
                if (manipulatedTile.transform.parent == selectionControl.ramka.transform)
                {
                    manipulatedTile.transform.parent = null;
                }
            }

            someDictionary[els_buf].GetComponent<tile_col>().onAir = true;
            someDictionary[els_buf].GetComponent<Rigidbody>().AddForce(new Vector3(0, 350, 0));
            someDictionary[els_buf].transform.parent = selectionControl.ramka.transform;
            manipulatedTile = someDictionary[els_buf];
            someDictionary[els_buf] = null;
        }
    }

    public void OnTileFall(GameObject tile_new)
    {

        Vector3Int coords = Vector3Int.RoundToInt(tile_new.transform.position);
        Color cellColor = nodes[coords.x, coords.z].obj.GetComponent<Renderer>().material.color;
        Color tileColor = tile_new.GetComponent<Renderer>().material.color;
        if (cellColor == tileColor)
            {
                Debug.Log("пик");
            testSound.Play();
            
            }


        
        if (tile_new.transform.parent == selectionControl.ramka.transform)
        {
            tile_new.transform.parent = null;
        }


        Vector3Int targetTilePosition = Vector3Int.RoundToInt(tile_new.transform.position);
        if (someDictionary[targetTilePosition] != null)
        {
            OnGameLose();
        }
        someDictionary.Remove(targetTilePosition);
        someDictionary.Add(targetTilePosition, tile_new);
    }

    private void RandomizeTilesPositions()
    {
      
        someDictionary.Clear();

        for (int num_2 = 0; num_2 < instancedTiles.Count; num_2++)
        {
            bool isRepeating = true;
            do
            {
                instancedTiles[num_2].transform.position = new Vector3(Random.Range(0, width), 0.015f, Random.Range(0, height));

                if (!someDictionary.ContainsKey(Vector3Int.RoundToInt(instancedTiles[num_2].transform.position)))
                {
                    isRepeating = false;
                }
            } while (isRepeating);
            someDictionary.Add(Vector3Int.RoundToInt(instancedTiles[num_2].transform.position), instancedTiles[num_2]);
        }
     
    }

    public void CompareColorsWinCheck()
    {
        bool isColorMatchesEverywhere = true;
        foreach (Vector3Int coords in someDictionary.Keys)
        {
            if(someDictionary[coords] == null)
            {
                //One of cells is empty...
                return;
            }

            Color cellColor = nodes[coords.x, coords.z].obj.GetComponent<Renderer>().material.color;
            Color tileColor = someDictionary[coords].GetComponent<Renderer>().material.color;
            if (cellColor != tileColor)
            {
                isColorMatchesEverywhere = false;
            }
           
        }
      
        if (isColorMatchesEverywhere) 
        {
            OnGameWin();
        }
    }

    public class Node
    {
        public bool isPlaceable;
        public Vector3 cellPosition;
        public Transform obj;
		internal object transform;

		public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;
        }
    }

    private void OnGameWin()
    {
        if (instantExtraTile.transform.parent == selectionControl.ramka.transform)
        {
            instantExtraTile.transform.parent = null;
        }
      
        Debug.Log("Все цвета совпали!");
		win_panel.SetActive(true);
        instantExtraTile.transform.position = new Vector3(1, 2, 1);
        instantExtraTile.GetComponent<Rigidbody>().useGravity = false;
        instantExtraTile.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        winUIElement.SetActive(true);
        isGameEnded = true;
    }

    private void OnGameLose()
    {
        menu_panel.SetActive(true);
        Debug.Log("You lose. Game Over!");
        loseUIElement.SetActive(true);
        isGameEnded = true;

    }
}
