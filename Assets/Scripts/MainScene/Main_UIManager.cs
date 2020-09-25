using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main_UIManager : MonoBehaviour
{
    public GameObject[] Scene;
    public Image ImagePAB;//press any button
    private int sceneNum;
    void Start()
    {
        sceneNum = 0;
        StartCoroutine(ImageAnimation());
    }

    public void PressAnyButton(){
        if(sceneNum < 1){
            PlayerPrefs.SetInt("MainScene", 1);
            Scene[0].SetActive(false);
            Scene[1].SetActive(true);
            sceneNum++;
            GetComponent<StageManager>().SetIsStage(true);
        }       
    }

    IEnumerator ImageAnimation(){//텍스트 깜빡이기
        
        yield return new WaitForSeconds(0.5f);
        if(ImagePAB.color.a > 0) ImagePAB.color = new Vector4(1f,1f,1f,0f);
        else ImagePAB.color = new Vector4(1f,1f,1f,1f);
        if(sceneNum==0)
            StartCoroutine(ImageAnimation());
    }
    //게임 종료버튼
    

}
