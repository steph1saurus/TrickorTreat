
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ReduceLifeScript : MonoBehaviour
{
    [Header("Max health points")]
    [SerializeField] public float initialLifePoints = 5;
    [SerializeField] public float currentLifePoints;

    [Header("Health bar")]
    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] public TextMeshProUGUI healthBarText;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }

    private void Start()
    {
        currentLifePoints = initialLifePoints;
        healthBar.UpdateHealthBar(currentLifePoints);
        // healthBarText.text = currentLifePoints + "/" + initialLifePoints ;

    }

    private void Update()
    {
        healthBarText.text = currentLifePoints + "/" + initialLifePoints ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ReduceLife();
        Debug.Log("hit");
    }

    public void ReduceLife()
    {
       
        currentLifePoints -= 1; //life points should go down based on weapon damage
        healthBar.UpdateHealthBar(currentLifePoints);

        //destroy Trick or Treater
        if (currentLifePoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Trick or Treater destroyed");
        }
    }

}
