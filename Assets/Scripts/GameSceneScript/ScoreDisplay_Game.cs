using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay_Game : MonoBehaviour
{
    private ScoreStarDisplay _ScoreStarDisplay;

    void Start()
    {
        _ScoreStarDisplay = GetComponent<ScoreStarDisplay>();
    }
    public void displayStarScore(int score)
    {
        _ScoreStarDisplay.displayStarScore(score);
    }
}
