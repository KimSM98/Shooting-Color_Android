using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManagerScript : MonoBehaviour
{
    public static AttackManagerScript instance;
    public GameObject AttackEffect;

    public Button[] ColorButtons; 
    public Button MiddleStarButton; 
    public Sprite[] ClickedColorButtonSprites;
    public Sprite[] MiddleStarButtonColors;
    public int SumOfColor = 0;
    public int PushedButtonNum = 0;

    private Sprite[] OriginCBSprites = new Sprite[5];
    int[] ClickedNum;

    public Button[] StarButton;
    public GameObject BossAttackedObj;
    int starNum;
    void Awake()
    {
        instance = this;
    }
  
   void Start()
   {
       BossAttackedObj.SetActive(false);
       if(SumOfColor == 0) MiddleStarButton.gameObject.SetActive(false);
       for(int i=0; i<ColorButtons.Length; i++){
           OriginCBSprites[i] = ColorButtons[i].image.sprite; //공격하면 원래대로 돌리기
       }
       ClickedNum = new int[2];
       starNum = 0;
       OffStarButton();
   }
   public void Attack(){
        
        MiddleStarButton.gameObject.SetActive(false);
        AttackEffect.SetActive(true);
        AttackEffect.GetComponent<AttackEffect>().StartAnim(SumOfColor);
        AttackEffect.GetComponent<AttackEffect>().SetisMove(true);
        OffAllClickedButton();//0606<<AttackEffect로
        ResetData();
   }

    public void ChangeMSBSprite(){ 
        if(SumOfColor != 0) MiddleStarButton.gameObject.SetActive(true);
        else if(SumOfColor == 0) MiddleStarButton.gameObject.SetActive(false);

        MiddleStarButton.image.sprite = MiddleStarButtonColors[SumOfColor];
    }//공격 후에는 false로(SumOfColor가 0이 되면 꺼짐)
    public void PushColorButton(int ColorNum, int ButtonArrayNum){
        ColorButtons[ButtonArrayNum].image.sprite = ClickedColorButtonSprites[ButtonArrayNum];
        ClickedNum[PushedButtonNum] = ButtonArrayNum;
        PushedButtonNum++;
        SumOfColor+=ColorNum;
    }
    public void releaseColorButton(int ColorNum, int ButtonArrayNum){//버튼에서 손을 뗏을 때 
        ColorButtons[ButtonArrayNum].image.sprite = OriginCBSprites[ButtonArrayNum];
        PushedButtonNum--;
        SumOfColor-=ColorNum;
    }
    void OffAllClickedButton(){
        for(int i=0; i<2; i++){
            ColorButtons[ClickedNum[i]].image.sprite = OriginCBSprites[ClickedNum[i]];
            ColorButtons[ClickedNum[i]].GetComponent<ColorButton>().SetIsPushed(false);
        }
    }
    public void ResetData(){
        SumOfColor = 0;    
        PushedButtonNum = 0;//0606
        
    }

    private void OffStarButton(){
        for(int i=0; i<StarButton.Length; i++){
            StarButton[i].gameObject.SetActive(false);
        }
    }

    public void StarButtonFunc(){
        if(!GameManager.instance.isGameOver && GameManager.instance.isBossMove == true){//게임 오버가 아니고 보스가 등장했을 떄 사용
            BossAttackedObj.SetActive(true);
            BossAttackedObj.GetComponent<Animator>().SetBool("IsAttacked", true);
            Boss.instance.Attacked();
        }        
    }

    public void ActiveStarButton(){
        if(starNum < 4 )//4번째까지 보여주고 5번째는 보스 나올때 보여줌
            StarButton[starNum].gameObject.SetActive(true);
        starNum++;
    }
    public void ActiveNumStar5(){
        //이렇게 한 이유, 별에 가운데 컬러 버튼에 생기기 때문에 게임 플레이에 방해가 있기 때문
        if(starNum > 4)
            StarButton[4].gameObject.SetActive(true);
    }

    public void DecreaseStarNum(bool isBossDead){
        starNum--;
    }

    
}
