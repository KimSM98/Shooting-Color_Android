using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStarDisplay : MonoBehaviour
{
    public Image[] scoreStars;
    
    public void displayStarScore(int score)
    {
        for(int i = 0; i < 3; i++)
        {
            scoreStars[i].gameObject.SetActive(false);
        }
        
        for(int i = 0; i < score; i++)
        {
            scoreStars[i].gameObject.SetActive(true);
        }
    }
}
