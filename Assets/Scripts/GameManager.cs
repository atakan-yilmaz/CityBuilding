using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1f;
    public float tileEndHeight = 1;

    [Space(8)]
    public TileObject[,] tileGrid = new TileObject[0, 0];

    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject stonePrefab;
    public Transform resourcesHolder;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;


    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //DIRECTLY SPAWN A TILE
                TileObject spawnedTile =  SpawnTile(x * tileSize, z * tileSize);

                //SETS THE tileObject WORLD SPACE DATA
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;

                //USING THE BOUNDS PARAMETERS
                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    //SPAWN THE OBSTACLE IN THERE
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        spawnedTile.data.SetOccupied(TileManager.ObstacleType.Resource);


                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                        tmpObstacle.SetTileReference(spawnedTile);
                    }
                }

                //ADDS THE SPAWNED VISUAL tileObject INSIDE THE LIST
                visualGrid.Add(spawnedTile);
            }
        }

        CreateGrid(visualGrid);
    }

    /// <summary>
    /// SPAWNS AND RETURNS A tileObject
    /// </summary>
    /// <param name="xPos">X Position inside the world</param>
    /// <param name="zPos">Z Position inside the world</param>
    /// <returns></returns>
    //SPAWNS AND RETURNS A "tileObject"
    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile" + xPos + " - " + zPos;

        return tmpTile.GetComponent<TileObject>();
    }

    /// <summary>
    /// WILL SPAWN A RESOURCE OBSTACLE DIRECTLY IN THE COORDINATES
    /// </summary>
    /// <param name="xPos">X Position of the obstacle</param>
    /// <param name="zPos">Z Position of the obstacle</param>
    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        //CHECK WHETHER WE SPAWN A WOOD OBSTACLE OR A STONE OBSTACLE
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood " + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(stonePrefab);
            spawnedObstacle.name = "Stone " + xPos + " - " + zPos;
        }

        //SETS THE POSITION AND THE PARENT OF THE SPAWNED RESOURCE
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
    }

    /// <summary>
    /// CREATE TILE GRID TO ADD BUILDINGS
    /// </summary>
    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        //SET THE SIZE OF OUR TILE GRID
        tileGrid = new TileObject[levelWidth, levelLength];

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //CONNECTLY THE tileGrid DIRECTLY TO THE VISUAL GRID
                tileGrid[x, z] = refVisualGrid.Find(v => v.xPos == x && v.zPos == z);
            }
        }
    }
}