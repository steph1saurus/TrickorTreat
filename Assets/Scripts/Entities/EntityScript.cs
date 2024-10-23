using UnityEngine;

public class EntityScript : MonoBehaviour
{

    [SerializeField] private bool isSentient = false;

    public bool IsSentient { get => isSentient; }

    private void Start()
    {
        if (GetComponent<PlayerController>())
        {
            GameManagerScript.instance.InsertEntity(this, 0);

        }
        else if (IsSentient)
        {
            GameManagerScript.instance.AddEntity(this);
        }

    }

    public void MoveEntity(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }
}
