using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 0.25f; // Default : 0.25f
    public List<MonsterAnimators> AnimatorControllerList;
    
    private GameSystem _GameSystem;
    private Dictionary<int, AnimatorOverrideController[]> _AnimControllerDic;
    private Animator _Animator;
    private int[] _StageColors;
    private int _CurrentColor = 0;
    private int _MaxNumOfColors;
    private int _NumOfColorChanges = 0;
    private Vector2 _InitPosition;
    private float _GameSpeed;
    private bool _IsCollidedWithPlayer = false;

    void Start()
    {
        // initialization
        initialize();

        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if(this.transform.position.x < -2.6f) 
            spawn();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(_GameSystem.getGameState() == GameSystem.GameState.inGame)
        {
            if(coll.CompareTag("AttackEffect"))
            {
                AttackEffect effect = coll.GetComponent<AttackEffect>();
                effect.startBrokenAnim();

                if(_CurrentColor == effect.getColor())
                {
                    _GameSystem.increaseMonsterKillCount();
                    gameObject.SetActive(false);

                    if(_GameSystem.getGameState() == GameSystem.GameState.inGame)
                        spawn();
                }
            }
            else if(coll.CompareTag("Player"))
            {
                if(!_IsCollidedWithPlayer)
                {
                    _GameSystem.decreasePlayerHp();
                    _IsCollidedWithPlayer = true;
                }
            }        
        }
    }

    // initialization
    private void initialize()
    {
        _Animator = GetComponent<Animator>();
        _GameSystem = GameSystem.instance;
        _InitPosition = this.transform.position;
        _GameSpeed = GameSystem.instance.gameSpeed;

        initializeMonsterAnimControllDic();
        initializeStageColors();
    }

    private void initializeMonsterAnimControllDic()
    {
        _AnimControllerDic = new Dictionary<int, AnimatorOverrideController[]>();

        for(int i = 0; i < AnimatorControllerList.Count; i++)
        {
            _AnimControllerDic.Add((int)AnimatorControllerList[i].color, AnimatorControllerList[i].animatorControllers);
        }
    }
    private void initializeStageColors()
    {
        _StageColors = GameStages.instance.getStageMonsterColor();
        _MaxNumOfColors = _StageColors.Length;
        
        randomizeStageColors();
    }    

    // Setter
    private void setMonsterColor()
    {
        if(_NumOfColorChanges == _MaxNumOfColors)
            randomizeStageColors();

        _CurrentColor = _StageColors[_NumOfColorChanges];
        _NumOfColorChanges++;
    }    

    private void setAnimController() 
    {
        if(_CurrentColor != 0)
        {
            AnimatorOverrideController[] animController = _AnimControllerDic[_CurrentColor];
            int type = Random.Range(0, animController.Length);

            _Animator.runtimeAnimatorController = animController[type];
        }
    }

    //function
    private void randomizeStageColors()
    {
        int randNum;
        int temp;
        for(int i = 0; i < _MaxNumOfColors; i++)
        {
            randNum = Random.Range(i, _MaxNumOfColors);
            temp = _StageColors[i];
            _StageColors[i] = _StageColors[randNum];
            _StageColors[randNum] = temp;      
        }

        _NumOfColorChanges = 0;
    }

    private void spawn()
    {
        this.transform.position = _InitPosition;
        _IsCollidedWithPlayer = false;
        
        setMonsterColor();
        setAnimController();
        gameObject.SetActive(true);
    }

    private void move()
    {
        transform.Translate( -1 * speed * _GameSpeed * Time.timeScale, 0, 0);
    }
}
