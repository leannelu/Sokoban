using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth : MonoBehaviour
{
    private GridObject gridObject;
    private Vector2Int currPos;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        currPos = gridObject.gridPosition;
        GridManager.reference.grid[currPos.x - 1, currPos.y - 1] = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
