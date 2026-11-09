using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody r;
    Transform t;
    float speed = 10;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode CheatKey = KeyCode.C;
    AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(z>0)
        {
            speed = 15;
            BGM.pitch = 1.5f;
        }
        else if(z<0)
        {
            speed = 5;
            BGM.pitch = 0.5f;
        }
        else
        {
            speed = 10;
            BGM.pitch = 1;
        }

        r.velocity = new Vector3(x*5, r.velocity.y , speed);
        if(Input.GetKeyDown(JumpKey) && r.position.y < 1.1)
        {
            Vector3 f = new Vector3(0, 5, 0);
            r.AddForce(f, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(CheatKey))
        {
            Vector3 f = new Vector3(0, 0, 397);
            t.localPosition = f;
        }

        if (r.position.y < -10)
        {
            GameObject.Find("GM").GetComponent<GM>().GameOver();
        }
    }
}
