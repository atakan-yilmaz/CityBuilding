using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int ResourceAmount = 10;
    TileObject refTile;


    /// <summary>
    /// THIS IS A METHOD THAT IT IS CALLED WHENEVER THE ITEM HAS BEED CLICKED OR TAPPED
    /// </summary>
    private void OnMouseDown()
    {
        //OnClick Event
        bool usedResource = false;

        //CALL DIRECTLY THE METHOD THAT ADDS THE RESOURCE
        switch (obstacleType)
        {
            case ObstacleType.Stone:

                usedResource = ResourceManager.Instance.AddStone(ResourceAmount);

                break;
            case ObstacleType.Wood:

                usedResource = ResourceManager.Instance.AddWood(ResourceAmount);

                break;
        }

        if (usedResource)
        {
            refTile.data.CleanTile();
            Destroy(gameObject);
        }
            
        else
            Debug.Log("Could not destroy. Because inventory is full");
    }

    public void SetTileReference(TileObject obj)
    {
        refTile = obj;
    }
    
    public enum ObstacleType
    {
        Stone,
        Wood
    }
}