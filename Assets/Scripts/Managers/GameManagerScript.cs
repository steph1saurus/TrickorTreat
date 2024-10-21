using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    [SerializeField] private float time = 0.1f;

    [SerializeField] private bool isPlayerTurn = true;


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


    private void Start()
    {
        Instantiate(Resources.Load<GameObject>("Player")).name = "Player";
    }


    public void EndTurn()
    {
        isPlayerTurn = false;
        StartCoroutine(WaitForTurns());
    }

    private IEnumerator WaitForTurns()
    {
        yield return new WaitForSeconds(time);
        isPlayerTurn = true;

    }

}