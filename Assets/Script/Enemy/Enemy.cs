using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* 敌人的基类
*/
public class Enemy : MonoBehaviour
{
    // 普通攻击伤害值
    public int attackDemage;
    // 血量
    public int Wealth;
    // 移动速度
    public float moveSpeed;
    // 动画对象
    protected Animator anim;
    // 死亡音效
    protected AudioSource deathAudio;
    public Rigidbody2D body;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // 收到攻击的事件
    public void Attacked(int demage){
        // demage 为传过来的伤害值
        Wealth -= demage;
        if (Wealth <= 0){
            Deadth();
        }
        anim.SetBool("Hit",true);
    }

    public void Attack(){
        if (!anim.GetBool("Attack")){
            anim.SetBool("Attack",true);
        }
        
    }

    public void Deadth(){
        anim.SetTrigger("Death");
        // Destroy(gameObject);
    }

    protected virtual void DeathDestroyGameObj(){
        Debug.Log("Destroy(gameObject)");
        Destroy(gameObject);
    }

}
