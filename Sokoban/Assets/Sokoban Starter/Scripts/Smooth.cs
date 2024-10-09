using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth : MonoBehaviour
{
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Pushed(Vector2Int pusherPos)
    {
        int xChange = movement.currPos.x - pusherPos.x;
        int yChange = movement.currPos.y - pusherPos.y;
        Vector2Int newPosition = new Vector2Int(movement.currPos.x + xChange, movement.currPos.y + yChange);
        print(newPosition);
        return movement.TryMovePosition(newPosition);
    }
}
