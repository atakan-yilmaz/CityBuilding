using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileObject : MonoBehaviour
{
    public TileManager data;

    [Header("World Tile Data")]
    [Space(8)]

    //POSITION OF THE TILE
    public int xPos = 0;
    public int zPos = 0;

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        if (!data.isOccupied)
        {
            if (GameManager.Instance.buildingToPlace != null)
            {
                GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, this);

                data.SetOccupied(TileManager.ObstacleType.Building);
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
}