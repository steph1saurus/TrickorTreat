
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [Header("Projectiles")]
    [SerializeField] public GameObject[] projectiles;
    [SerializeField] 

    public void ShootProjectile()
    {
        //Instantiate(projectiles[0],new Vector3(-7, 3, 0), Quaternion.identity);
        Instantiate(projectiles[Random.Range(0, projectiles.Length)], new Vector3(-7f, 2.5f, 0f), Quaternion.identity);
    }


    
}
