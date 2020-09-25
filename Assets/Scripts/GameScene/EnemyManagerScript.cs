using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public static EnemyManagerScript instance;
    public GameObject EnemyObj;
    public AnimatorOverrideController[] AnimController;
    Animator EnemyAnim;
   // Dictionary<int,AnimatorOverrideController[]> Dic;//이부분 수정
    Dictionary<int,AnimatorOverrideController> DicEnemy; //AnimControllerNum, Color
 
    int[] SpawnEnemyArr;
    Dictionary<int, int[]> DicSpawnInfo;
    Dictionary<int, List<AnimatorOverrideController>> DicAnimController;
    int enemyCount = 0;
    void Awake()
    {        
        instance = this;
        DicAnimController = new Dictionary<int, List<AnimatorOverrideController>>();//0617
        DicEnemy = new Dictionary<int, AnimatorOverrideController>();
        DicSpawnInfo = new Dictionary<int, int[]>();

        AssignDic();
        //AssignSpawnEnemyNum();
    }
    void Start()
    {
        //0618
        SpawnEnemyArr = GameManager.instance.GetSpawnEnemyArr();
        //0618
        EnemyAnim = new Animator();
        EnemyAnim = EnemyObj.GetComponent<Animator>();
        //0616
        SpawnEnemy();
        swapEnemyArray(); // 0923
    }
    public void SpawnEnemy(){
        int EnemyNum = GetRandomNum();//Stage에서 등장하는 컬러num
        EnemyObj.GetComponent<Enemy>().SetColorNum(EnemyNum);//여기가 문제2
        EnemyAnim.runtimeAnimatorController = DicEnemy[EnemyNum];
    }
    
    private void AssignDic(){
        int[] colorArray = {1,2,2,3,4,5,6,8,9,10,12,15,16,17,19,19,23};
        
        //for(int i=0; i<AnimController.Length; i++){
        for(int i=0; i<colorArray.Length; i++){
            DicEnemy[colorArray[i]]= AnimController[i];
        }
    }
    void swapEnemyArray(){
        int temp;
        for(int i=0; i<SpawnEnemyArr.Length-i; i++){
            int randnum = Random.Range(i,SpawnEnemyArr.Length-1);
            temp = SpawnEnemyArr[i];
            SpawnEnemyArr[i]= SpawnEnemyArr[randnum];
            SpawnEnemyArr[randnum] = temp;
        }
    }
    int GetRandomNum(){
        if(enemyCount < SpawnEnemyArr.Length-1){
            enemyCount++;            
        } 
        else{
            swapEnemyArray();
            enemyCount = 0;
        }
        //0923
        //int num = Random.Range(0,SpawnEnemyArr.Length);//여기가 문제1
        return SpawnEnemyArr[enemyCount];
    }

}
