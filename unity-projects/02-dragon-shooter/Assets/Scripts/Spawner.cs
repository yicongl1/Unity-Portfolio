using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> monsters;

    public float minTime = 0.5f;
    public float maxTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while(true)
        {
            float t = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(t);
            int i = Random.Range(0, monsters.Count);//随机怪物下标
            Vector3 pos = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y, 0);//随机怪物位置
            Transform m = Instantiate(monsters[i], pos, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
