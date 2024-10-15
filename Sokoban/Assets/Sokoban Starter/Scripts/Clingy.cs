using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clingy : MonoBehaviour
{
    public Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = this.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
