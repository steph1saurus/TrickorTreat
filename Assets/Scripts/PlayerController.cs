using UnityEngine;


public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void Update()
    {
    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManagerScript.instance.IsPlayerTurn)
        {
            Debug.Log("Players turn");
        }
    }

    
}
