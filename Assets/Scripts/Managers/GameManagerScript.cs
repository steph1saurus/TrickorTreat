using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    [SerializeField] private float time = 5f;

    [SerializeField] private bool isPlayerTurn = true;

    [SerializeField] private GameObject player;

    [SerializeField] GameObject notPlayerTurnPanel;

   
    [Header("Number of Entities")]
    [SerializeField] private int entityNum = 0;
    [SerializeField] private List<EntityScript> entities = new List<EntityScript>();



    public bool IsPlayerTurn { get => isPlayerTurn;  }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void StartTurn()
    {

        //player = Resources.Load<GameObject>("Prefabs/Player");
        //Instantiate(player, new Vector3(-12, 3, 0), Quaternion.identity).name = "Player";

        notPlayerTurnPanel = GameObject.Find("NotPlayerTurnPanel");

        // Ensure the panel is hidden at the start if the player's turn is active
        if (notPlayerTurnPanel != null)
        {
            notPlayerTurnPanel.SetActive(!isPlayerTurn);
        }
        else
        {
            Debug.LogWarning("NotPlayerTurn panel not found!");
        }

        if (entities[entityNum].GetComponent<PlayerController>())
        {
            isPlayerTurn = true;
            notPlayerTurnPanel.SetActive(false);
        }

        else if (entities[entityNum].IsSentient)
        {
            ActionClass.SkipTurn(entities[entityNum]);
        }
    }


    public void EndTurn()
    {
        //isPlayerTurn = false;
        
        if(entities[entityNum].GetComponent<PlayerController>())
        {
            isPlayerTurn = false;
            notPlayerTurnPanel.SetActive(true);
        }

        if (entityNum == entities.Count-1)
        {
            entityNum = 0;
        }

        else
        {
            entityNum++;
        }

        StartCoroutine(TurnDelay());
        //StartCoroutine(WaitForTurns());
    }

    private IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(time);
        StartTurn();

    }

    public void AddEntity(EntityScript entity)
    {
        entities.Add(entity);
    }


    public void InsertEntity(EntityScript entity, int index)
    {
        entities.Insert(index, entity);
    }

}
