using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    [SerializeField] private float time = 5f;

    [SerializeField] private bool isPlayerTurn = true;

    

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



    public void StartPlayerTurn()
    {
        notPlayerTurnPanel = GameObject.Find("NotPlayerTurnPanel");
        isPlayerTurn = true;
        notPlayerTurnPanel.SetActive(false);
    }

    public void StartNPCTurn()
    {
        // Create a direction vector for movement (-1 along x-axis)
        Vector2 direction = new Vector2(-1, 0);
        ActionClass.Movement(entities[entityNum], direction);

        EndNPCTurn();
    }


    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        notPlayerTurnPanel.SetActive(true);
    }

    public void EndNPCTurn()
    {
        TurnDelay();
        Debug.Log("end NPC turn");
    }

    private IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(time);
        StartPlayerTurn();
    }

    public void AddEntity(EntityScript entity)
    {
        entities.Add(entity);
    }


    public void InsertEntity(EntityScript entity, int index)
    {
        entities.Insert(index, entity);
    }

    public EntityScript GetBlockingEntityLocation(Vector3 location)
    {
        foreach(EntityScript entity in entities)
        {
            if (entity.BlocksMovement && entity.transform.position == location)
            {
                return entity;
            }
        }
        return null;
    }

}
