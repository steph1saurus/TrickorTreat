using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    
    [Header("Prefabs")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject NPC;

    [Header("Monsters")]
    [SerializeField] private int maxMonsters = 4;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPosition = new Vector3(-11f, -2.5f, 0f);

        CreateEntity("Player", playerPosition);
        GameManagerScript.instance.StartPlayerTurn();
    }

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
