using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyStar : MonoBehaviour
{
    public Image Image_StarOn;
    
    public void OnStar(){
        Image_StarOn.gameObject.SetActive(true);
    }
    public void OffStar(){
        Image_StarOn.gameObject.SetActive(false);
    }
}
