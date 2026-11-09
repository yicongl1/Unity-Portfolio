using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor
{
    Red,
    Green,
}

public class PlayerChar : MonoBehaviour
{
    //各种组件
    Rigidbody rigid;
    Animator anim;
    Renderer render;
    PlayerColor color;

    public float speed = 10;
    public float jumpSpeed = 5;
    public Transform dieRedParticle;
    public Transform dieGreenParticle;

    private int jumpCount = 0;
    private bool isGround = true;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        render = GetComponentInChildren<Renderer>();
        render.material.color = Color.red;
        color = PlayerColor.Red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Green" || tag == "Red")
        {
            jumpCount = 0;
            isGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Green" || tag == "Red")
        {
            jumpCount = 0;
            isGround = true;
        }

        if (color == PlayerColor.Green && tag == "Red")
        {
            PlayerDie();
        }
        else if (color == PlayerColor.Red && tag == "Green")
        {
            PlayerDie();
        }
    }

    public void Move(bool jump, bool changeColor)
    {
        Vector3 vel = rigid.velocity;
        vel.z = speed;
        if (jump && jumpCount < 1)
        {
            jumpCount++;
            vel.y = jumpSpeed;
            isGround = false;
        }
        rigid.velocity = vel ;

        anim.SetBool("IsGround",isGround);

        if (changeColor)
        {
            ChangeColor(changeColor);
        }
    }

    private void ChangeColor(bool changecolor)
    {
        if (color == PlayerColor.Red)
        {
            color = PlayerColor.Green;
            render.material.color = Color.green;
        }
        else
        {
            color = PlayerColor.Red;
            render.material.color = new Color(0.95f,0.95f,0.03f);//
            render.material.color = Color.red;
        }

        anim.SetTrigger("Change");
    }

    private void DelayPlayerDie()
    {
        GameMode.Instance.OnPlayerDie();
    }

    private void PlayerDie()
    {
        gameObject.SetActive(false);
        Transform prefab = dieRedParticle;
        if(color == PlayerColor.Green)
        {
            prefab = dieGreenParticle;
        }
        Transform p = Instantiate(prefab, transform.position, Quaternion.identity);

        Invoke("DelayPlayerDie", 1);
    }

}
