using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TileManager
{
    //BUILDING REFERENCE THAT EACH TILE WILL HAVE FOR EACH BUILDING
    public BuildManager buildingRef;

    public ObstacleType obstacleType;

    bool isStarterTile = true;

    //THE STUFF THAT THE TILE IS BEING OCCUPIED BY
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    #region Methods
    public void SetOccupied(ObstacleType t)
    {
        obstacleType = t;
    }

    public void SetOccupied(ObstacleType t, BuildManager bM)
    {
        obstacleType = t;
        buildingRef = bM;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;
    }
    #endregion

    #region Booleans
    public bool isOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }
    }
    #endregion
}