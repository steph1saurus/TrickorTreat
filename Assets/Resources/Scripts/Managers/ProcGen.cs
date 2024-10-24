using System.Collections.Generic;
using UnityEngine;

sealed class ProcGen : MonoBehaviour
{
    public void GenerateLevel(int mapWidth, int mapHeight, int roomMaxSize, List<RoomsScript> rooms)
    {
        int roomWidth = roomMaxSize;
        int roomHeight = roomMaxSize;

        int roomX = 0;
        int roomY = 0;

        RoomsScript newRoom = new RoomsScript(roomX, roomY, roomWidth, roomHeight);

       for (int x= roomX; x <roomX + roomWidth; x++)
        {
            for (int y = roomY; y< roomY + roomHeight; y++)
            {
                if (x ==roomX || x==roomX + roomWidth - 1 || y == roomY || y == roomY + roomHeight - 1)
                {
                    if (SetWallTileIfEmpty(new Vector3(x, y, 0)))
                    {
                        continue;
                    }
                }
                else
                {
                    MapManager.instance.FloorMap.SetTile(new Vector3Int(x, y, 0), MapManager.instance.FloorTile);
                }
               
            }
        }

        Vector3 playerPosition = new Vector3(-11f, -2.5f, 0f);

        MapManager.instance.CreateEntity("Player", playerPosition);
    }


}
