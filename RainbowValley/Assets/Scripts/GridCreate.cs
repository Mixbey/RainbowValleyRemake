using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public GameObject cellsPrefab;
    public GameObject playerPrefab;
    public GameObject obstaclePrefab;
    public GameObject destructiblePrefab;
    public GameObject[,] gridArray;
    public float spacing = 1.1f;
    public float playerHeightOffSet = 1.0f;
    public Color green;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        GenerateBorder();
        //GenerateObstacles();
        //SpawnPlayer();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateGrid()
    {
        gridArray = new GameObject[height, width];

        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                Vector3 cellPosition = new Vector3(x * spacing, 0, y * spacing);
                GameObject newCell = Instantiate(cellsPrefab, cellPosition, Quaternion.identity);
                Renderer blockRenderer = newCell.GetComponent<Renderer>();
                gridArray[x, y] = newCell;
                if ((x + y) % 2 == 0)
                {
                    blockRenderer.material.color = green;
                }
                if (x == 0 || x == height - 1 || y == 0 || y == width - 1)
                {
                    blockRenderer.material.color = GetRainbowColor((x + y) / (float)(width + height));
                }
            }
        }
    }
    //public void GenerateObstacles()
    //{
    //    for (int x = 0; x < height; x++)
    //    {
    //        for (int y = 0; y < width; y++)
    //        {
    //            float randomValue = Random.Range(0, 1f);
    //            if (gridArray[x, y].transform.childCount > 0)
    //            {
    //                Vector3 ObstaclePosition = gridArray[x, y].transform.position;
    //                GameObject obstacle = Instantiate(obstaclePrefab, ObstaclePosition + Vector3.up * 1f, Quaternion.identity);
    //                obstacle.transform.SetParent(gridArray[x, y].transform);
    //                Renderer blockRenderer = obstacle.GetComponent<Renderer>();
    //                blockRenderer.material.color = GetRainbowColor((x + y) / (float)(width + height));
    //                obstacle.transform.parent = this.transform;
    //                continue;
    //            }
    //        }
    //    }
    //}

    public void SpawnPlayer()
    {
        bool playerSpawned = false;
        while (!playerSpawned)
        {
            int randomX = Random.Range(0, height);
            int randomY = Random.Range(0, width);

            if (gridArray[randomX, randomY].transform.childCount == 0)
            {
                Vector3 cellPosition = gridArray[randomX, randomY].transform.position;
                Vector3 spawnPosition = new Vector3(cellPosition.x, cellPosition.y + playerHeightOffSet, cellPosition.z);
                Instantiate(playerPrefab, spawnPosition + Vector3.up, Quaternion.identity);
                playerSpawned = true;
            }
        }
    }
    public void GenerateBorder()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (x == 0 || x == height - 1 || y == 0 || y == width - 1)
                {
                    Vector3 bordersPositions = gridArray[x, y].transform.position;
                    GameObject border = Instantiate(obstaclePrefab, bordersPositions + Vector3.up * 1f, Quaternion.identity);
                    border.transform.SetParent(gridArray[x, y].transform);
                    Renderer blockRenderer = border.GetComponent<Renderer>();
                    blockRenderer.material.color = GetRainbowColor((x + y) / (float)(width + height));
                }
            }
        }
    }
    Color GetRainbowColor(float value)
    {
        float r = Mathf.Sin(value * Mathf.PI * 2) * 0.5f + 0.5f;
        float g = Mathf.Sin((value + 0.33f) * Mathf.PI * 2) * 0.5f + 0.5f;
        float b = Mathf.Sin((value + 0.66f) * Mathf.PI * 2) * 0.5f + 0.5f;
        return new Color(r, g, b);
    }
}

