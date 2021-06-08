using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public static AttackEffect instance;
    public List<AttackEffectSprite> spriteList = new List<AttackEffectSprite>();
    public float speed = 0.5f;
    public bool isMove = false;

    // Components
    Rigidbody2D rigid;
    SpriteRenderer sprRenderer;
    
    private Dictionary<int, Sprite[]> attackEffectSprDic;
    private Sprite[] currentSprites;
    private Vector2 initPos;
    private float initSpeed;
    private int _Color;
    private float _GameSpeed;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        
        // initialization
        initializeColorDictionary();
        _GameSpeed = GameSystem.instance.gameSpeed;
        initPos = this.transform.position;
        initSpeed = speed;

        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isMove == true) Move();
        else initializePos();
    }

    public void Move()
    {
        if(this.transform.position.x > 2.25f){
            isMove = false;
        } 
        this.transform.Translate(speed * _GameSpeed * Time.timeScale, 0, 0); //임시
        //this.transform.Translate(Speed*GameManager.instance.Speed*Time.timeScale, 0,0);
    }

    void initializePos(){
        speed = initSpeed;
        this.transform.position = initPos;
        
        this.gameObject.SetActive(false);
    }

    void initializeColorDictionary(){        
        attackEffectSprDic = new Dictionary<int, Sprite[]>();

        for(int i = 0; i < spriteList.Count; i++)
        {
            attackEffectSprDic.Add((int)spriteList[i].color, spriteList[i].sprites);
        }

        Debug.Log("dictionary setting is succeed");
    }

    // NEW START ANIMATION 210527
    public void startAttackAnim(int color)
    {
        _Color = color;
        isMove = true;
        gameObject.SetActive(true);

        StartCoroutine(ShootingAnimation());
    }
    public void startBrokenAnim()
    {
        StartCoroutine(BrokenAnimation());
    }

    IEnumerator ShootingAnimation(){
        currentSprites = (Sprite[])attackEffectSprDic[_Color];

        for(int i = 0; i < currentSprites.Length - 3 ; i++)
        {
            sprRenderer.sprite = currentSprites[i];
            yield return new WaitForSeconds(0.025f);
        }
    }
    IEnumerator BrokenAnimation(){        
        speed = 0;

        for(int i = currentSprites.Length - 3; i < currentSprites.Length; i++)
        {
            sprRenderer.sprite = currentSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
        
        initializePos();
    }

    // Getter
    public int getColor()
    {
        return _Color;
    }
}
