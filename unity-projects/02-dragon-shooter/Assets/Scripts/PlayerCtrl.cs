using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public KeyCode fireCode = KeyCode.J;
    PlayerChar player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerChar>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, v, 0);

        player.Move(move);

        if (Input.GetKey(fireCode))
        {
            player.Fire();
        }
    }
}
