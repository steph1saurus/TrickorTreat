using UnityEngine;

public class DestroyOutOfBoundsScript : MonoBehaviour
{
    [SerializeField] private float rightBound = 10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
