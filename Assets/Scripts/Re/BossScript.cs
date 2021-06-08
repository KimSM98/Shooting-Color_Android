using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static BossScript instance;

    public float speed = 0.1f;
    public AnimatorOverrideController[] bossAnimaionControllers;
    public GameObject bossHpBar;
    public GameObject attackedEffect;

    private Animator _Animator;
    private int _Hp = 5;
    private HpBar _HpBarComponent;
    private BossAttackEffect _BossAttackEffectComponent;
    private float _GameSpeed;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();

        initialize();
    }

    void Update()
    {
        if(transform.position.x > -3.3f && 
            GameSystem.instance.getGameState() == GameSystem.GameState.bossStage)
            move();
        else
            hideBossObject();
    }

    void initialize()
    {
        _Hp = GameStages.instance.getBossHp();
        _GameSpeed = GameSystem.instance.gameSpeed;

        _BossAttackEffectComponent = attackedEffect.GetComponent<BossAttackEffect>();
        _HpBarComponent = bossHpBar.GetComponent<HpBar>();
        _HpBarComponent.setHp(_Hp);

        setRandomizeBossAnimation();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            GameSystem.instance.enterGameOverState();
        }
    }
    void move()
    {
        transform.Translate(-1 * speed * _GameSpeed * Time.timeScale, 0, 0);
    }

    public void attackBoss()
    {
        // hp == 0일 때 보스 죽음, 게임 클리어
        _Hp--;
        _BossAttackEffectComponent.PlayAttackEffectAnimation();
        _HpBarComponent.decreaseHpUI();

        if(_Hp < 1)
        {
            playDeadAnimation();
        }
    }

    void playDeadAnimation()
    {
        _Animator.SetTrigger("Dead");
    }

    void bossDead() // DeadAnimation이 끝나고 발생하는 event이다.
    {
        GameSystem.instance.enterGameClearState();
        // GameSystem.instance.setGameState(GameSystem.GameState.gameClear);
        // GameSystem.instance.displayGameClearUI();

        bossHpBar.SetActive(false);
        hideBossObject();
    }

    void hideBossObject()
    {
        gameObject.SetActive(false);
    }

    void setRandomizeBossAnimation()
    {
        int randNum = Random.Range(0, bossAnimaionControllers.Length);

        _Animator.runtimeAnimatorController = bossAnimaionControllers[randNum];
    }
}
