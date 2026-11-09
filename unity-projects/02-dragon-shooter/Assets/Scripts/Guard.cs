using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float hitTime = 0.1f;  //受击持续时间
    public float hp = 20;
    public float minY = 2.6f;
    public float minX = -2.1f;
    public float maxX = 2.1f;
    public float speed = 3;
    public Transform prefabBoom;
    private SpriteRenderer[] renders;
    private float changeColorTime;
    private Vector3 pos;
    private State state = State.Down;
    // Start is called before the first frame update

    enum State
    {
        Down,
        LeftRight,
    }

    void Start()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
    }

    void SetColor(Color c)
    {
        if (renders[0].color == c) return;
        foreach (var r in renders)
        {
            r.color = c;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SetColor(Color.blue);
        changeColorTime = Time.time + hitTime;

        hp -= 1;
        if(hp<=0)
        {
            Destroy(gameObject);
            Instantiate(prefabBoom,transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
        switch (state)
        {
            case State.Down:
                pos = transform.position + Vector3.down * speed * Time.deltaTime;
                if (pos.y >= minY)
                {
                    transform.position = pos;
                }
                else
                    state = State.LeftRight;
                break;
            case State.LeftRight:
                if (transform.position.x <= minX)
                {
                    speed = -Mathf.Abs(speed);
                }
                else if(transform.position.x > maxX)
                {
                    speed = Mathf.Abs(speed);
                }
                transform.position += Vector3.left * speed * Time.deltaTime;
                break;
        }
    }
}
