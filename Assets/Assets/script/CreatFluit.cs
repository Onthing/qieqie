using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFluit : MonoBehaviour {

    public GameObject[] fruite;
    int index;
	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, -20, 0);
        InvokeRepeating("Move", 4, 10);

    }

    // Update is called once per frame
    void Update () {

    }
    void Move()
    {
        float x= Random.Range(-7, 7);
        index = Random.Range(0, 7);
        GameObject go = Instantiate(fruite[index], new Vector3(x, -7, -9), Quaternion.identity);
        if (x > 0)
        {
            go.transform.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 0), 55.0f, 0);
        }
        else
        {
            go.transform.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 5), 55.0f, 0);
        }
        //go.transform.localEulerAngles.z = Random.Range(-120, 120);
    }
}
