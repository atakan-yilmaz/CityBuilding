using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager
{
    //BUILDING REFERENCE THAT EACH TILE WILL HAVE FOR EACH BUILDING
    public BuildManager buildingRef;

    //TILE IS OCCUPIED BY SOMETHING?
    public bool occupied;

    public ObstacleType obstacleType;

    //THE STUFF THAT THE TILE IS BEING OCCUPIED BY
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void SetOccupied(ObstacleType t, BuildManager bM)
    {
        occupied = true;
        obstacleType = t;

        buildingRef = bM;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
        occupied = false;
    }
}