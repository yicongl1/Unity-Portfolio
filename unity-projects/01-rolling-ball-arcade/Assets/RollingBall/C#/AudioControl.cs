using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = transform.GetComponent<AudioSource>();
        BGM.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale!=0)
        {
            BGM.enabled = true;
        }
        else
        {
            BGM.enabled = false;
        }
    }

}
