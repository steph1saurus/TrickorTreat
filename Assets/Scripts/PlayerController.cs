using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerControls controls;
    [SerializeField] public int buttonsClicked = 0;

    [SerializeField] public Button[] buttons;

    private void Awake()
    {
        controls = new PlayerControls();

        // Find all GameObjects with the "Button" tag and get their Button components
        GameObject[] buttonObjects = GameObject.FindGameObjectsWithTag("Button");
        buttons = new Button[buttonObjects.Length];

        for (int i = 0; i < buttonObjects.Length; i++)
        {
            buttons[i] = buttonObjects[i].GetComponent<Button>();

            // Add the OnClicked method to each button's onClick event
            if (buttons[i] != null)
            {
                buttons[i].onClick.AddListener(OnClicked);
            }
            else
            {
                Debug.LogWarning("No Button component found on " + buttonObjects[i].name);
            }
        }
    }
   

    private void OnEnable()
    {
        controls.Enable();
        

    }
    private void OnDisable()
    {
        controls.Disable();
        
    }

    private void OnClicked()
    {
        buttonsClicked += 1;
        Debug.Log("Buttons clicked: " + buttonsClicked);
        PlayerClicking();
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManagerScript.instance.IsPlayerTurn)
        {
            PlayerClicking();
        }
        
    }

    private void PlayerClicking()

    {
        if (buttonsClicked == 4)
        {
            Debug.Log("Player turn ended");
            GameManagerScript.instance.EndTurn();
            buttonsClicked = 0;
        }
        
        
    }
}
