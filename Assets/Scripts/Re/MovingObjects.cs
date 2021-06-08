using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    //종류 랜덤
    public float speed = -0.005f; // cloud: -0.05f tree: -0.2f
    public GameObject[] ObjectPatterns;
    public Vector2 startPos = new Vector2(6f, 2.6f); // cloud(5.3f, 2.6f), Tree(7f, 0)
    public Vector2 endPos = new Vector2(-4.7f, 2.6f); // cloud(-4.7f, 2.6f), Tree(-6f)

    private int _Type;
    private int _CurrentType = 0;
    private float _GameSpeed = 1f;

    void Start()
    {
        _Type = ObjectPatterns.Length;
        _GameSpeed = GameSystem.instance.gameSpeed;

        changePattern();
    }

    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;

        if(posX > endPos.x) 
            move();
        else 
            initialize();
    }

    void move()
    {
        transform.Translate(speed * _GameSpeed * Time.timeScale, 0, 0);
    }

    void initialize()
    {
        transform.position = startPos;
        changePattern();
    }
    
    void changePattern()
    {
        ObjectPatterns[_CurrentType].SetActive(false);
        _CurrentType = Random.Range(0, _Type);
        ObjectPatterns[_CurrentType].SetActive(true);
    }
}
