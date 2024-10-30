using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissorScript : MonoBehaviour
{
    [Header("Text field")]
    [SerializeField] public TextMeshProUGUI resultText;

    [Header("RPS choices")]
    [SerializeField] public Button rockButton;
    [SerializeField] public Button paperButton;
    [SerializeField] public Button scissorButton;

    [Header("Choice icons")]

    [SerializeField] public Sprite[] choiceIcon;
    
    [SerializeField] public Image playerChoiceIcon;
    [SerializeField] public Image enemyChoiceIcon;

    [Header("Choice")]
 
    [SerializeField] private int playerButtonChoice;
    [SerializeField] private int enemyButtonChoice;
    [SerializeField] private int choice;
    [SerializeField] private int enemyChoice;

    [Header("Panels")]
    [SerializeField] public GameObject RPSWindow;
    [SerializeField] public GameObject deactivatePlayerChoices;

    [Header("Bools")]
    [SerializeField] private bool picked = false;
    [SerializeField] private bool playerWon;


    private void Start()
    {

        deactivatePlayerChoices.SetActive(false);

        rockButton.onClick.AddListener(delegate { PlayerChoice(0); });
        rockButton.onClick.AddListener(delegate { EnemyChoice(Random.Range(0,3)); });
        paperButton.onClick.AddListener(delegate { PlayerChoice(1); });
        paperButton.onClick.AddListener(delegate { EnemyChoice(Random.Range(0, 3)); });
        scissorButton.onClick.AddListener(delegate { PlayerChoice(2); });
        scissorButton.onClick.AddListener(delegate { EnemyChoice(Random.Range(0, 3)); });

    }

    private void Update()
    {
        if (picked && choice!=enemyChoice)
        {
            deactivatePlayerChoices.SetActive(true);
            ResultCriteria();
            StartCoroutine(CloseRPS());
        }
        else if (picked && choice ==enemyChoice)
        {
            resultText.text = "Draw";
            deactivatePlayerChoices.SetActive(false);
            StartCoroutine(ResetChoices());
        }

       
    }

    private void PlayerChoice(int playerButtonChoice)
    {
        switch (playerButtonChoice)
        {
            case 0:
               playerChoiceIcon.sprite = choiceIcon[0];
                choice = 0;
                picked = true;
                break;
            case 1:
                playerChoiceIcon.sprite = choiceIcon[1];
                deactivatePlayerChoices.SetActive(true);
                choice = 1;
                picked = true;

                break;
            case 2:
                playerChoiceIcon.sprite = choiceIcon[2];
                deactivatePlayerChoices.SetActive(true);
                choice = 2;
                picked = true;
                break;

        }

    }

    //random enemy choice picker
    private void EnemyChoice(int enemyButtonChoice)
    {


        switch (enemyButtonChoice)
        {
            case 0:
                enemyChoiceIcon.sprite = choiceIcon[0];
                enemyChoice = 0;
                ResultCriteria();
                break;
            case 1:
                enemyChoiceIcon.sprite = choiceIcon[1];
                enemyChoice = 1;
                ResultCriteria();
                break;
            case 2:
                enemyChoiceIcon.sprite = choiceIcon[2];
                enemyChoice = 2;
                ResultCriteria();
                break;
            
        }

    }

    private void ResultCriteria()
    {
        if (picked)
        { 
            if (choice == 0 && enemyChoice == 1)
            {
                resultText.text = "Lose!";
                playerWon = true;
            }
            else if (choice == 0 && enemyChoice == 2)
            {
                resultText.text = "Win!";
                playerWon = false;
                
            }

            else if (choice == 1 && enemyChoice == 0)
            {
                resultText.text = "Win!";
                playerWon = true;
               
            }
            else if (choice == 1 && enemyChoice == 2)
            {
                resultText.text = "Lose!";
                playerWon = false;
               
            }
            else if (choice == 2 && enemyChoice == 0)
            {
                resultText.text = "Lose!";
                playerWon = false;
             
            }
            else if (choice == 2 && enemyChoice == 1)
            {
                resultText.text = "Win!";
                playerWon = true;
               
            }
        }
        
    }

    private IEnumerator ResetChoices()
    {
        yield return new WaitForSeconds(1);
        picked = false;
        playerChoiceIcon.sprite = null;
        enemyChoiceIcon.sprite = null;
        resultText.text = "";
        choice = 0;
        enemyChoice = 0;
    }


    private IEnumerator CloseRPS()
    {
        yield return new WaitForSeconds(3);
        RPSWindow.SetActive(false);
        UpdateLifePoints();
        
    }

    private void UpdateLifePoints()
    {
        if(!playerWon)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ReduceLifeScript>().currentLifePoints -=1;
            
        }
    }


}
