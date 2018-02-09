using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByKnife : MonoBehaviour {
    bool isClick = false;
    Collider collide;
	// Use this for initialization
	void Start () {
        collide = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        //bool isMouseDown = Input.GetMouseButtonDown(0);
        if (!isClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log("hited1");
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log("hited2");
                    if (hit.transform.tag == "Knife")
                    {
                        Debug.Log("hited3");
                        transform.GetComponent<KnifRay>().isHit = true;
                        transform.GetComponent<KnifRay>().rayPosition = hit.transform.position;
                    }
                 
                }
            }
        }
    }
}
