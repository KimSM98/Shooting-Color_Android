using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundScript : MonoBehaviour
{
    public GameObject[] Obj_BGCloud;
    public float CloudSpeed;
    public GameObject[] Obj_BGTree;
    public float TreeSpeed;

    private MovingObject Cloud;
    private MovingObject Tree;
    
    void Start()
    {
        Cloud = new MovingObject();
        Tree = new MovingObject();

        Cloud.PreviousPosition = Obj_BGCloud[0].transform.position;
        Tree.PreviousPosition = Obj_BGTree[0].transform.position;
    }
    void Update()
    {
        Move(CloudSpeed, Obj_BGCloud, Cloud, Cloud.PreviousPosition, 0f, -4.6f);
        Move(TreeSpeed, Obj_BGTree, Tree, Tree.PreviousPosition, -1.7f, -6.3f);
        
    }
    void Move(float moveSpeed, GameObject[] obj, MovingObject MovingObj, Vector2 movePos, float middleX, float endX){ 

        if(obj[MovingObj.CurrentNum].transform.position.x < middleX){//중간지나면
            MovingObj.PreviousNum = MovingObj.CurrentNum;
            MovingObj.CurrentNum++;
        }
        if(obj[MovingObj.PreviousNum].transform.position.x < endX){
            obj[MovingObj.PreviousNum].transform.position = movePos;
            MovingObj.PreviousNum = MovingObj.CurrentNum;
        }
        if(MovingObj.CurrentNum > obj.Length-1) MovingObj.CurrentNum = 0;

        
        obj[MovingObj.CurrentNum].transform.Translate(moveSpeed*GameManager.instance.Speed*Time.timeScale, 0, 0);

        if(MovingObj.PreviousNum != MovingObj.CurrentNum) obj[MovingObj.PreviousNum].transform.Translate(moveSpeed*GameManager.instance.Speed*Time.timeScale, 0, 0);

    }
    

}
