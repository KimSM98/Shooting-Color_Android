using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public int CurrentNum{get; set;}
    public int PreviousNum{get; set;}
    public Vector2 PreviousPosition{get; set;}

    public MovingObject(){
        CurrentNum = 0;
        PreviousNum = 0;
        PreviousPosition = new Vector2(0,0);
    }  
   
}
