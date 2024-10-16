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
    void Update()
    {

    }


}
