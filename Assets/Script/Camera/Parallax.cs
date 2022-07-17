using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* 该文件处理背景远近移动。
* 设置 moveRate, 越外层的背景该数值应该越小
*/
public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float moveRate;
    private float startPointX,startPointY;
    public bool lockY; //false
    // Start is called before the first frame update
    void Start()
    {
        // 获取相机对象 transform
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        startPointX = transform.position.x;
        startPointY = transform.position.y;
    }

    // Update is called once per frame
    void Update(){
        if(lockY){
            transform.position = new Vector2(startPointX+Cam.position.x*moveRate,transform.position.y);
        }else{
            transform.position = new Vector2(startPointX+Cam.position.x*moveRate,startPointY+Cam.position.x*moveRate);
        }
        
    }
}
