using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacked : MonoBehaviour
{
    public void StarButtonFunc_Reset(){
        GetComponent<Animator>().SetBool("IsAttacked", false);
        gameObject.SetActive(false);
    }
}
