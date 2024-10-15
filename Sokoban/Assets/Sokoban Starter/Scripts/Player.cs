using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = this.GetComponent<Movement>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.TryMovePosition(new Vector2Int(movement.currPos.x, movement.currPos.y + 1));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.TryMovePosition(new Vector2Int(movement.currPos.x, movement.currPos.y - 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.TryMovePosition(new Vector2Int(movement.currPos.x - 1, movement.currPos.y));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.TryMovePosition(new Vector2Int(movement.currPos.x + 1, movement.currPos.y));
        }
    }

    /*
    //returns true if successfully moved, false otherwise
    public bool TryMovePosition(Vector2Int goalPosition)
    {
        if(goalPosition.x >= 1 && goalPosition.x <= GridMaker.reference.dimensions.x && goalPosition.y >= 1 && goalPosition.y <= GridMaker.reference.dimensions.y)
        {
            GameObject goalPosObject = GridManager.reference.grid[goalPosition.x - 1, goalPosition.y - 1];
            if (goalPosObject == null)
            {
                MovePosition(goalPosition);
                return true;
            }
            else if(goalPosObject.CompareTag("smooth"))
            {
                Smooth smooth = goalPosObject.GetComponent<Smooth>();
                if(smooth.Pushed(currPos))
                {
                    MovePosition(goalPosition);
                    return true;
                }
            }
        }
        return false;
    }

    public void MovePosition(Vector2Int goalPosition)
    {
        GridManager.reference.grid[currPos.x - 1, currPos.y - 1] = null;
        GridManager.reference.grid[goalPosition.x - 1, goalPosition.y - 1] = this.gameObject;
        currPos = goalPosition;
        gridObject.gridPosition = goalPosition;
    }

    
    */
}
