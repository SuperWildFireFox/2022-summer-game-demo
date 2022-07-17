using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* 该文件为玩家的攻击帧与敌人接触判定
*/
public class Attack : MonoBehaviour
{
    // 伤害值
    public int attackDemage = 1;
    // public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // 当攻击帧的 collider 与敌人发生 trigger 碰撞时，触发事件
    private void  OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("collision Judge!...");
        if (collision.gameObject.tag == "Enemy"){
            Debug.Log("collision Judge!...");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log(enemy);
            enemy.Attacked(attackDemage);
        }
    }
}
