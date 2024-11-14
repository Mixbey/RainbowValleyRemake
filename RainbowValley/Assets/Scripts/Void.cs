using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] int width, height, depth;
    [SerializeField] GameObject pref;
    [SerializeField] Transform parent;

    int[,,] grid;

    void Awake()
    {
        transform.position = new(90, 20, 0);
        Generate();
    }

    void Generate()
    {
        grid = new int[width, height, depth];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 pos = new(x, y, z);

                    Instantiate(pref, pos + Vector3.up * 1, Quaternion.identity, parent);
                }
            }
        }
    }
}
