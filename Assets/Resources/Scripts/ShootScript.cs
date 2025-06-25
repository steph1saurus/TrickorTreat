
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootScript : MonoBehaviour
{
    [Header("Projectiles")]
    [SerializeField] public GameObject[] projectiles;
    [SerializeField] private GameObject shootPoint;

    private Vector3 shootPointVector3;

    public void Start()
    {
        shootPointVector3 = shootPoint.transform.position;
    }
    public void ShootProjectile()
    {
        //Instantiate(projectiles[0],new Vector3(-7, 3, 0), Quaternion.identity);
        Instantiate(projectiles[Random.Range(0, projectiles.Length)], shootPointVector3, Quaternion.identity);
    }
    

    
}
