using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitTime = 0.1f;  //受击持续时间
    public float hp = 3;
    public float speed = 3;
    public Transform prefabBoom;
    private SpriteRenderer[] renders;
    private float changeColorTime;
    // Start is called before the first frame update
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
        SetColor(Color.red);
        changeColorTime = Time.time + hitTime;

        hp -= 1;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(prefabBoom, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y < -10 || transform.position.y>10)
        {
            Destroy(gameObject);
        }
    }
}
