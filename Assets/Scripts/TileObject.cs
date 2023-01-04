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
                List<TileObject> iteratedTiles = new List<TileObject>();

                bool canPlaceBuildingHere = true;

                //CHECK ADJACENT TILE
                for (int x = xPos; x < xPos + GameManager.Instance.buildingToPlace.data.width; x++)
                {
                    if (canPlaceBuildingHere)
                    {
                        for (int z = zPos; z < zPos + GameManager.Instance.buildingToPlace.data.length; z++)
                        {
                            iteratedTiles.Add(GameManager.Instance.tileGrid[x, z]);

                            if (GameManager.Instance.tileGrid[x, z].data.isOccupied)
                            {
                                canPlaceBuildingHere = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);
                }
                else
                {
                    Debug.Log("Could not place building");
                }
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
}