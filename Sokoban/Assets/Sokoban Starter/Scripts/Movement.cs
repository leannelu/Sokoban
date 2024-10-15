using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int currPos;
    public bool pushable;
    public List<Movement> stuckToMe;
    public List<Movement> clungToMe;
    private bool hasLeft;
    private bool hasRight;
    private bool hasUp;
    private bool hasDown;
    private GameObject pushedBy;
    private void Awake()
    {
        pushable = false;
    }
    void Start()
    {
        stuckToMe = new List<Movement>();
        gridObject = GetComponent<GridObject>();
        currPos = gridObject.gridPosition;
        GridManager.reference.grid[currPos.x - 1, currPos.y - 1] = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        CheckAdjacent(GridManager.reference.grid[currPos.x - 1, currPos.y]);
        CheckAdjacent(GridManager.reference.grid[currPos.x + 1, currPos.y]);
        CheckAdjacent(GridManager.reference.grid[currPos.x, currPos.y + 1]);
        CheckAdjacent(GridManager.reference.grid[currPos.x, currPos.y - 1]);*/

        if (currPos.x > 1) 
            hasLeft = true;
        else
            hasLeft = false;
        if (currPos.x < GridMaker.reference.dimensions.x) 
            hasRight = true;
        else
            hasRight = false;
        if (currPos.y > 1) 
            hasUp = true;
        else
            hasUp = false;
        if (currPos.y < GridMaker.reference.dimensions.y) 
            hasDown = true;
        else
            hasDown = false;

    }

    //returns true if successfully moved, false otherwise
    public bool TryMovePosition(Vector2Int goalPosition)
    {
        if (goalPosition.x >= 1 && goalPosition.x <= GridMaker.reference.dimensions.x && 
            goalPosition.y >= 1 && goalPosition.y <= GridMaker.reference.dimensions.y)
        {
            GameObject goalPosObject = GridManager.reference.grid[goalPosition.x - 1, goalPosition.y - 1];
            if (goalPosObject == null)
            {
                MovePosition(goalPosition);
                return true;
            }
            else
            {
                if (goalPosObject.TryGetComponent<Movement>(out Movement goalPosObjMov))
                {
                    if(goalPosObjMov.pushable)
                    {
                        print(this.tag + " pushing" + goalPosObjMov.tag);
                        if (goalPosObjMov.Pushed(this.gameObject, currPos))
                        {
                            TryMovePosition(goalPosition);
                            return true;
                        }
                    }
                }

            }
        }
        return false;
    }

    public void MovePosition(Vector2Int goalPosition)
    {
        int gridX = currPos.x - 1;
        int gridY = currPos.y - 1;
        GridManager.reference.grid[gridX, gridY] = null;
        GridManager.reference.grid[goalPosition.x - 1, goalPosition.y - 1] = this.gameObject;
        int xChange = goalPosition.x - currPos.x;
        int yChange = goalPosition.y - currPos.y;
        currPos = goalPosition;
        gridObject.gridPosition = goalPosition;
        //check if adjacent objects are sticky and move them if they are
        print(this.tag + " moved to " + goalPosition);
        print(this.tag + " checking stickies");
        //TO FIX: stack overflow when sticky tries to push a smooth, probably because the smooth is also trying to bring the sticky(bad)
        if (hasRight) TryStickyMove(GridManager.reference.grid[gridX + 1, gridY], goalPosition, xChange, yChange);
        if (hasLeft) TryStickyMove(GridManager.reference.grid[gridX - 1, gridY], goalPosition, xChange, yChange);
        if (hasDown) TryStickyMove(GridManager.reference.grid[gridX, gridY + 1], goalPosition, xChange, yChange);
        if (hasUp) TryStickyMove(GridManager.reference.grid[gridX, gridY - 1], goalPosition, xChange, yChange);
    }

    public bool Pushed(GameObject pusher, Vector2Int pusherPos)
    {
        int xChange = currPos.x - pusherPos.x;
        int yChange = currPos.y - pusherPos.y;
        Vector2Int newPosition = new Vector2Int(currPos.x + xChange, currPos.y + yChange);
        print(this.tag + " pushed to " + newPosition);
        this.pushedBy = pusher;
        return TryMovePosition(newPosition);
    }
    
    private void TryStickyMove(GameObject adjacent, Vector2Int goalPosition, int xChange, int yChange)
    {
        if (adjacent != null)
        {
            if (adjacent.TryGetComponent<Sticky>(out Sticky sticky))
            {
                print("adjacent: " + adjacent + " pushed by: " + pushedBy);
                if(sticky.movement.currPos != goalPosition && adjacent != pushedBy)
                {
                    int newX = sticky.movement.currPos.x + xChange;
                    int newY = sticky.movement.currPos.y + yChange;
                    Vector2Int newPos = new Vector2Int(newX, newY);
                    print("sticky new pos is " + newPos);
                    sticky.movement.TryMovePosition(newPos);
                }
            }
        }
    }


}
