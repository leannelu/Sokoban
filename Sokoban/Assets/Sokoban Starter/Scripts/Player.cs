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

}
