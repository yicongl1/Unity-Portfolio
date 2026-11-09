using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingball : MonoBehaviour
{
    // Start is called before the first frame update
    Transform r;
    float speed = 0.01f;
    void Start()
    {
        r = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 f = new Vector3(speed, 0, 0);
        r.localPosition += f;
        if (r.position.x < -3.5)
        {
            speed = 0.01f;
        }
        if (r.position.x > 3.5)
        {
            speed = -0.01f;
        }

    }
}
