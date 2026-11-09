using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBox : MonoBehaviour
{
    [Range(0, 3)] public int para;
    Rigidbody rigid;
    LightManage lightManage;
    int index;
    public float rotateSpeed=200;
    public float moveSpeed=5;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = ColorManage.SetColor(para);
        rigid = GetComponent<Rigidbody>();
        lightManage = FindObjectOfType<LightManage>();
        index=Random.Range(0, lightManage.lights.Length);
    }
    Transform parent;
    // Update is called once per frame
    void Update()
    {
        parent = transform.parent;
        if (!parent)
        {
            WayFinding();
            rigid.isKinematic = false;
        }
        else
            rigid.isKinematic = true;
    }

    void WayFinding()
    {
        Vector3 pos = lightManage.lights[index].transform.position;
        Quaternion dir = Quaternion.LookRotation(pos - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, dir, rotateSpeed * Time.deltaTime);
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, pos) <= 2)
            index++;
        if (index == lightManage.lights.Length)
            index = 0;
    }
}
