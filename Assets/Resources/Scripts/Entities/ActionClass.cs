using UnityEngine;

static public class ActionClass
{
    static public void Movement(EntityScript entity, Vector2 direction)
    {
        entity.MoveEntity(direction);
        GameManagerScript.instance.EndNPCTurn();
    }

    static public void SkipTurn(EntityScript entity)
    {
        GameManagerScript.instance.EndNPCTurn();
    }

    static public bool BumpAction(EntityScript entity, Vector2 direction)
    {
        EntityScript target = GameManagerScript.instance.GetBlockingEntityLocation(entity.transform.position + (Vector3)direction);
        if (target)
        {
            MeleeAction(target);
            return false;
                
        }
        else
        {
            Movement(entity, direction);
            return true;
        }
    }

    static public void MeleeAction(EntityScript target)
    {
        GameManagerScript.instance.EndNPCTurn();
    }


}

