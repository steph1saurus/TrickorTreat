
using UnityEngine;

public class CandyMovementScript : MonoBehaviour
{
    [SerializeField] public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
