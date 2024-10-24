using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [Header("Prefabs")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject NPC;

    [Header("Room specs")]
    [SerializeField] private int width = 100;
    [SerializeField] private int height = 80;
    [SerializeField] private int roomMaxSize = 100;

    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;
    [SerializeField] private Tilemap floorMap;

    public TileBase FloorTile { get => floorTile; }
    public TileBase WallTile { get => wallTile; }
    public Tilemap FloorMap { get => floorMap; }

    [Header("Features")]
    [SerializeField] private List<RoomsScript> rooms = new List<RoomsScript>();
    public List<RoomsScript> Rooms { get => rooms; }

    [Header("Monsters")]
    [SerializeField] private int maxMonsters = 4;

    // Start is called before the first frame update
    void Start()
    {
        ProcGen procGen = new ProcGen();
        procGen.GenerateLevel(width, height, roomMaxSize, rooms);

        GameManagerScript.instance.StartPlayerTurn();
    }

    public bool InBounds(int x, int y) => 0 <= x && x < width && 0 <= y && y < height;

    public void CreateEntity(string entity, Vector3 position)
    {
        switch (entity)
        { case "Player":
                Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3(position.x, position.y, 0f), Quaternion.identity).name = "Player";
                break;
            case "Pumpkin":
                Instantiate(Resources.Load<GameObject>("Prefabs/Pumpkin"), new Vector3(position.x, position.y, 0f), Quaternion.identity).name = "Pumpkin";
                break;
            case "Mummy":
                Instantiate(Resources.Load<GameObject>("Prefabs/Mummy"), new Vector3(position.x, position.y, 0f), Quaternion.identity).name = "Mummy";
                break;
            case "Vampire":
                Instantiate(Resources.Load<GameObject>("Prefabs/Vampire"), new Vector3(position.x, position.y, 0f), Quaternion.identity).name = "Vampire";
                break;
            case "Boxkid":
                Instantiate(Resources.Load<GameObject>("Prefabs/BoxKid"), new Vector3(position.x, position.y, 0f), Quaternion.identity).name = "BoxKid";
                break;
            default:
                Debug.Log("Error: Entity not found");
                break;

        }

    }

    private void PlaceEntities(int maxMonsters)
    {
        int numberOfMonsters = maxMonsters + 1;
        for (int monster = 0; monster < maxMonsters;)
        {
          
        }



    }
}
