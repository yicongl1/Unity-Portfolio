using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertask : MonoBehaviour
{
    Rigidbody rigid;
    Transform body;
    Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Texture image = Resources.Load<Texture>("image");
        GetComponent<MeshRenderer>().material.mainTexture = image;
        body = transform.Find("Body");
        body.GetComponent<MeshRenderer>().material.color = Color.black;
        hand = body.Find("Hands");
        BoxCollider[] hands = hand.GetComponentsInChildren<BoxCollider>();
        foreach(var hand in hands)
        {
            hand.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
    public float moveSpeed;

    public void Move(float x,float z)
    {
        x *= Time.deltaTime * moveSpeed;
        z *= Time.deltaTime * moveSpeed;
        rigid.velocity = new Vector3(x,rigid.velocity.y,z);
    }
    public float limit_x, limit_z;

    public void PosLimit()
    {

        Vector3 pos = transform.position;
        if (pos.x < -limit_x) pos.x = -limit_x;
        else if (pos.x > limit_x) pos.x = limit_x;
        if (pos.z < -limit_z) pos.z = -limit_z;
        else if (pos.z > limit_z) pos.z = limit_z;
        transform.position = pos;
    }
    public LayerMask layer;

    public void BodyCharacter()
    {
        body.position = transform.position + Vector3.up;
        body.rotation = new Quaternion(0, body.rotation.y, 0, body.rotation.w);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 100, layer))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
            Vector3 lookTarget = new Vector3(hit.point.x, body.position.y, hit.point.z);
            body.LookAt(lookTarget);
        }
    }

    public bool stretching = false;
    bool stretch = true;
    public float maxLength;
    public float pullSpeed;

    public void Pull()
    {
        if (stretching)
        {
            Vector3 scale = hand.localScale;
            if (stretch)
                scale.z += Time.deltaTime * pullSpeed;
            else
                scale.z -= Time.deltaTime * pullSpeed;
            if (scale.z <= 1)
            {
                scale.z = 1;
                stretching = false;
            }
            if (scale.z == 1)
                stretch = true;
            else if (scale.z >= maxLength)
                stretch = false;
            hand.localScale = scale;
        }
    }

    Transform box;

    private void OnTriggerEnter(Collider other)
    {
        if (!box && stretching && other.GetComponent<PullBox>())
            box = other.transform;
    }

    public void PickUp()
    {
        if(box)
        {
            stretch = false;
            box.parent = body;
            Vector3 pos = body.position + body.forward * 2;
            box.position = Vector3.MoveTowards(box.position, pos, Time.deltaTime * pullSpeed);
            box.rotation = Quaternion.Lerp(box.rotation, body.rotation, Time.deltaTime * 5);
        }
    }
    public void PutDown()
    {
        if(box)
        {
            box.SetParent(null);
            box = null;
        }
    }
}
