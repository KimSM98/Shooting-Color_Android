using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay_Main : MonoBehaviour
{
    public Text infinityModeScoreText;
    public GameObject scoreStarGroup;

    private ScoreStarDisplay _ScoreStarDisplay;

    void Awake()
    {
        _ScoreStarDisplay = GetComponent<ScoreStarDisplay>();
    }

    public void SetScore(int score)
    {
    }

    public void displayStarScore(int score)
    {
        infinityModeScoreText.gameObject.SetActive(false);
        scoreStarGroup.SetActive(true);

        _ScoreStarDisplay.displayStarScore(score);
    }
    public void displayInfinityModeScore(int score)
    {
        scoreStarGroup.SetActive(false);
        infinityModeScoreText.gameObject.SetActive(true);

        infinityModeScoreText.text = "Score: " + score;
    }

}
