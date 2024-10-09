using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GridObject gridObject;
    private Vector2 dimensions;
    private Vector2Int currPos;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        dimensions = GridMaker.reference.dimensions;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = gridObject.gridPosition;
        if (Input.GetKeyDown(KeyCode.S))
        {
            movePosition(new Vector2Int(currPos.x, currPos.y + 1));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            movePosition(new Vector2Int(currPos.x, currPos.y - 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movePosition(new Vector2Int(currPos.x - 1, currPos.y));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movePosition(new Vector2Int(currPos.x + 1, currPos.y));
        }
    }

    public void movePosition(Vector2Int goalPosition)
    {
        print(currPos);
        print(goalPosition);
        if(goalPosition.x >= 1 && goalPosition.x <= dimensions.x && goalPosition.y >= 1 && goalPosition.y <= dimensions.y)
        {
            if (GridManager.reference.grid[goalPosition.x - 1, goalPosition.y - 1] == null)
            {
                gridObject.gridPosition = goalPosition;
            }
        }
    }
}
