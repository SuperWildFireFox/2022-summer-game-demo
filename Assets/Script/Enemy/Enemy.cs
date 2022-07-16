using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* 敌人的基类
*/
public class Enemy : MonoBehaviour
{
    // 动画对象
    protected Animator anim;
    // 死亡音效
    protected AudioSource deathAudio;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attacked(){

    }

    public void Deadth(){
        anim.SetBool("Death",true);
        // Destroy(gameObject);
    }

    public void DeathDestroyGameObj(){
        Debug.Log("Destroy(gameObject)");
        Destroy(gameObject);
    }

}
