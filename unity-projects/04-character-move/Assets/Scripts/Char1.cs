using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1 : MonoBehaviour
{
    public float speed = 3;
    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, 0, v);
    }

    void Move(float x, float y, float z)
    {
        // 世界坐标系
        move = new Vector3(x, y, z);

        // 要看向的位置
        if (move.sqrMagnitude > 0.0001f)
        {
            Vector3 to = transform.position + move;
            transform.LookAt(to); // LookAt 接收的是目标点，而不是方向向量
        }

        // 移动
        transform.position += move * speed * Time.deltaTime;
    }
}
