
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [Header("Projectiles")]
    [SerializeField] public GameObject[] projectiles;

    public void ShootProjectile()
    {
        Instantiate(projectiles[0],new Vector3(-7, 3, 0), Quaternion.identity);

    }
}
