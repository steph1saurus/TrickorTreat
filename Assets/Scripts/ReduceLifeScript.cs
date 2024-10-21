
using UnityEngine;

public class ReduceLifeScript : MonoBehaviour
{
    [Header("Max health points")]
    [SerializeField] public float initialLifePoints = 5;
    [SerializeField] public float currentLifePoints;

    [Header("Health bar")]
    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }

    private void Start()
    {
        currentLifePoints = initialLifePoints;
        healthBar.UpdateHealthBar(currentLifePoints);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        ReduceLife();
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
