using UnityEngine;

static public class ActionClass
{

    static public void Escape()
    {

    }

    static public void Movement(EntityScript entity, Vector2 direction)
    {
        entity.MoveEntity(direction);
        GameManagerScript.instance.EndTurn();
    }

    static public void SkipTurn(EntityScript entity)
    {
        GameManagerScript.instance.EndTurn();
    }

}

