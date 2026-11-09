using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 3)] public int para;
    Color color;
    Material material;
    public bool isBright;
    void Start()
    {
        color = ColorManage.SetColor(para);
        GetComponent<MeshRenderer>().material.color = color;
        material = transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == color)
        {
            isBright = true;
            material.color = color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == color)
        {
            isBright = false;
            material.color = Color.white;
        }
    }

    void Update()
    {

    }
}
