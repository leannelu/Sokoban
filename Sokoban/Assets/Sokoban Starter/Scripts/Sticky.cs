using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    public Movement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = this.GetComponent<Movement>();
        movement.pushable = true;
    }
    /*
    // Update is called once per frame
    void Update()
    {
        GameObject leftObj = GridManager.reference.grid[movement.currPos.x - 1, movement.currPos.y];
        GameObject rightObj = GridManager.reference.grid[movement.currPos.x + 1, movement.currPos.y];
        GameObject UpObj = GridManager.reference.grid[movement.currPos.x, movement.currPos.y + 1];
        GameObject downObj = GridManager.reference.grid[movement.currPos.x, movement.currPos.y - 1];

        if (leftObj != null) StickTo(leftObj);
        if (rightObj != null) StickTo(rightObj);
        if (UpObj != null) StickTo(UpObj);
        if (downObj != null) StickTo(downObj);
    }

    private void StickTo(GameObject obj)
    {
        if (obj != null)
        {
            Movement objMovement = obj.GetComponent<Movement>();
            if (objMovement != null)
            {
                objMovement.stuckToMe.Add(this.gameObject);
            }
        }
    }*/


}
