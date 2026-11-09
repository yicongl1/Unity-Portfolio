using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private bool jump;
    private bool changeColor;
    private PlayerChar pchar;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Change = KeyCode.J;

    private void Start()
    {
        pchar = GetComponent<PlayerChar>();
        jump = false;
        changeColor = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(Jump))
        {
            jump = true;
        }
        if(Input.GetKeyDown(Change))
        {
            changeColor = true;
        }
    }

    private void FixedUpdate()
    {
        pchar.Move(jump,changeColor);
        jump = false;
        changeColor = false;
    }
}
