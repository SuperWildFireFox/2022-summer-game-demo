using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwithBounds : MonoBehaviour
{
    //TODO: 切换场景后更改调用
    private void Start() {
        SwitchConfinerShape();
    }
    private void SwitchConfinerShape()
    {
        PolygonCollider2D confinerShape = GameObject.FindGameObjectWithTag("BoundsConfiner").GetComponent<PolygonCollider2D>();
        
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        
        confiner.m_BoundingShape2D = confinerShape;

        // 修改了碰撞边界
        confiner.InvalidatePathCache();
    }
}
