using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GridObject gridObject;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        GridManager.reference.grid[gridObject.gridPosition.x - 1, gridObject.gridPosition.y - 1] = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
