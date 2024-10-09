using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager reference;
    public GameObject[,] grid;
    private Vector2 dimensions;

    // Start is called before the first frame update
    void Start()
    {
        dimensions = GridMaker.reference.dimensions;
        reference = this;
        grid = new GameObject[(int)dimensions.x, (int)dimensions.y];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
