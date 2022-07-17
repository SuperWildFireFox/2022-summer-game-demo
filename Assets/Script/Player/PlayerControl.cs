using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D player;
    public Collider2D coll;
    private Animator anim;
    [Header("移动参数")]
    public float speed;
    //翻滚速度
    private float rollSpeed;
    private float xVelocity;

    [Header("跳跃参数")]
    public float jumpForce = 2f;

    public LayerMask ground;

    [Header("玩家状态")]
    // 生命值
    public int health;
    public UI_PlayerStatus ui_PlayerStatus;
    

    // Start is called before the first frame update
    void Start()
    {
        rollSpeed = speed;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerHealthChanged();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Roll();
        Attack();
        Block();
    }

    private void FixedUpdate() {
        PlayerMovement();
        SwitchAnim();
    }
    // 移动
    public void PlayerMovement()
    {
        xVelocity = Input.GetAxis("Horizontal");
        // Debug.Log(xVelocity);
        FilpDirection();
        // 在某些时候不应该允许移动，比如防御的时候
        if (!anim.GetBool("Block")){
            player.velocity = new Vector2(xVelocity * speed*Time.deltaTime*60, player.velocity.y);
            anim.SetFloat("Running", Mathf.Abs(xVelocity));
        }
        

        // 跳跃
        //if (Input.GetKeyDown(KeyCode.C) && coll.IsTouchingLayers(ground))
        
        // Croush();
    }
    // 角色朝向翻转
    void FilpDirection()
    {
        if (xVelocity < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (xVelocity > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    // 格挡防御
    void Block(){
        if (Input.GetKeyDown(KeyCode.C) ){
            if (!anim.GetBool("Block")){
                anim.SetBool("Block", true);
                if (anim.GetFloat("Running") > 0.1f){
                    player.velocity = new Vector2(0f * speed, player.velocity.y);
                    anim.SetFloat("Running", Mathf.Abs(0f));
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.C) ){
            
            anim.SetBool("Block", false);
            
        }
    }
    // 跳跃
    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) ){
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            // jumpAudio.Play();
            anim.SetBool("Jumping", true);
            // anim.SetBool("Idle", false);
        }
    }
    // 翻滚
    void Roll(){
        if (Input.GetKeyDown(KeyCode.Z) ){
            if ((anim.GetFloat("Running")>0.1f || 
                anim.GetBool("Idle")) &&
                (!anim.GetBool("Jumping") && !anim.GetBool("Falling") && !anim.GetBool("Rolling"))){
                anim.SetBool("Rolling", true);
                if (anim.GetFloat("Running")>0.1f){
                    // player.AddForce(new Vector2(jumpForce,0f), ForceMode2D.Impulse);
                    speed = speed + rollSpeed;
                }
                // anim.SetBool("Idle", false);
            }
            
        }
    }
    // 翻滚结束
    void RollEnd(){
        anim.SetBool("Rolling", false);
        if (anim.GetFloat("Running")>0.1f){
            speed = rollSpeed;
        }
        
    }
    // 攻击判定
    void Attack(){
        if (Input.GetKeyDown(KeyCode.X) ){
            if ( !anim.GetBool("Rolling")
                ){
                anim.SetBool("Attack", true);
            }
            
        }
    }
    // 攻击结束
    void AttackEnd(){
        anim.SetBool("Attack", false);
    }
    //动画切换
    void SwitchAnim()
    {
        anim.SetBool("Idle", false);
        if(player.velocity.y<0.1f && !coll.IsTouchingLayers(ground)){
            anim.SetBool("Falling",true);
        }
        if (anim.GetBool("Jumping"))
        {
            if(player.velocity.y < 0)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        // else if (isHurt)
        // {
        //     anim.SetBool("Hurt", true);
        //     //anim.SetFloat("Running", 0);
        //     if (Mathf.Abs(player.velocity.x) < 0.1f)
        //     {
        //         anim.SetBool("Hurt", false);
        //         anim.SetBool("Idle", true);
        //         isHurt = false;
        //     }
        // }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }
    }

    // 遭受伤害
    public void Hurted(int demage){
        anim.SetBool("Hurt",true);
        health -= demage;
        // 生命值变化触发函数
        PlayerHealthChanged();
        if (health <= 0){
            anim.SetTrigger("Death");
        }
    }
    // 遭受伤害结束
    public void EndHurt(){
        anim.SetBool("Hurt",false);
    }
    // 死亡销毁人物
    public void DeadthDestoryPlayer(){
        Destroy(gameObject);
    }

    // 生命值发生变化时触发函数
    public void PlayerHealthChanged(){
        ui_PlayerStatus.HeathChanged(health);
    }
}
