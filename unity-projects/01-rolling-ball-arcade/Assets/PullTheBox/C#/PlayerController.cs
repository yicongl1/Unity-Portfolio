using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Playertask character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Playertask>();
    }

    // Update is called once per frame
    void Update()
    {
        character.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        character.PosLimit();
        character.BodyCharacter();
        if (Input.GetMouseButtonDown(0))
            character.stretching = true;
        character.Pull();
        character.PickUp();
        if (Input.GetMouseButtonDown(1))
            character.PutDown();
    }
}
