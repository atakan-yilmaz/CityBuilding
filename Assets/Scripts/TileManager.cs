using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager
{
    //BUILDING REFERENCE THAT EACH TILE WILL HAVE FOR EACH BUILDING
    public BuildManager buildingRef;

    //TILE IS OCCUPIED BY SOMETHING?
    public bool occupied;

    //THE STUFF THAT THE TILE IS BEING OCCUPIED BY
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }
}