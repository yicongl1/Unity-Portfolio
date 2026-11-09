using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManage : MonoBehaviour
{
    public Lamp[] lights;
    // Start is called before the first frame update
    void Awake()
    {
        lights = transform.GetComponentsInChildren<Lamp>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllLightIsBright())
        {
            GameObject.Find("GM").GetComponent<GM>().Win();
        }
    }
    bool AllLightIsBright()
    {
        foreach(var light in lights)
        {
            if(!light.isBright)
                return false;
        }
        return true;
    }
}
