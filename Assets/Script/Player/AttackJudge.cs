using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackJudge : MonoBehaviour
{
    // 判定的 collider2D 对象
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 开始攻击判定
    void BeginAttack1Judge(){
        coll.enabled = true;
    }
    // 结束攻击判定
    void EndAttack1Judge(){
        coll.enabled = false;
    }
}
