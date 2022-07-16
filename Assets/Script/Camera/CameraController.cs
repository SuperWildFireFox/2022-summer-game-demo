using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 摄像机镜头移动速度
    public float speed = 3.0f;

    // Player 所在位置
    public Transform playerPosition;

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 targetposition = new Vector3(playerPosition.position.x, playerPosition.position.y, gameObject.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * speed);
    }
}
