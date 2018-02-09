using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifRay : MonoBehaviour {
    public Color color;
    public GameObject myRay;
    private GameObject rayGameObject;
    [HideInInspector]
    public AudioSource knifeSound;
    public bool isHit = false;
    public Vector3 rayPosition;
    public bool isRay = false;
    public GameObject firstFlute;
    public GameObject secondFlute;
    private GameObject myFirstFlute;
    private GameObject mySecondFlute;

    public GameObject spalsh;
    public GameObject spalshH;
    public GameObject spalshV;

    private float ungle;
    
    Vector3 firstPos;
    Vector3 secondPos;
    Vector3 thirdPos;
    bool isClick = false;
    private LineRenderer line;
    void Start () {
        line = GetComponent<LineRenderer>();
        line.material.color = color;
        line.startWidth = 0.01f;
        line.endWidth=0.01f;
        knifeSound = GetComponent<AudioSource>();
        line.enabled = false;
    }
	
	void Update () {
        bool isMouseDown = Input.GetMouseButtonDown(0);
        if (!isHit)
        {
            if (isMouseDown && !isClick)
            {
                firstPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                //line.SetVertexCount(1);
                line.positionCount = 1;
                line.enabled = true;
                line.SetPosition(0, firstPos);
                isClick = false;

            }
            else if (isMouseDown)
            {
                secondPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                line.positionCount = 2;
                line.SetPosition(1, secondPos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isRay = true;
                isClick = false;
                secondPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                line.positionCount = 2;
                line.SetPosition(1, secondPos);
                if (firstPos.x != secondPos.x)
                {
                    ungle = Mathf.Atan((secondPos.y - firstPos.y) / (secondPos.x - firstPos.x));
                }
               
                else
                {
                    ungle = 0;
                }
                //Debug.Log(ungle);
                if ((ungle < 30 && ungle > 0) || ((ungle < 0) && (ungle > -30)))
                {
                    GameObject go = Instantiate(spalshH, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                    Destroy(go, 1.0f);
                }
                else if ((ungle < 90 && ungle > 60) || ((ungle < -60) && (ungle > -90)))
                {
                    GameObject go = Instantiate(spalshV, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                    Destroy(go, 1.0f);
                }
                else
                {
                    GameObject go = Instantiate(spalsh, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                    Destroy(go, 1.0f);
                }
                thirdPos = (firstPos + secondPos) / 2.0f;
                rayGameObject = Instantiate(myRay, thirdPos,
                Quaternion.AngleAxis(ungle * 10 / 0.12f, Vector3.forward));
                myFirstFlute = Instantiate(firstFlute, transform.position,
                Quaternion.AngleAxis(Random.Range(50, 180) * 180 / 3.14f, thirdPos));
                mySecondFlute = Instantiate(secondFlute, transform.position,
                Quaternion.AngleAxis(Random.Range(80, 150) * 100 / 0.14f, Vector3.forward));
                if (Random.Range(1, 10) > 5.0)
                {
                    myFirstFlute.GetComponent<Rigidbody>().velocity = new Vector2(5, 10);
                    mySecondFlute.GetComponent<Rigidbody>().velocity = new Vector2(5, 10);
                }
                else
                {
                    myFirstFlute.GetComponent<Rigidbody>().velocity = new Vector2(-5, 10);
                    mySecondFlute.GetComponent<Rigidbody>().velocity = new Vector2(8, -10);

                }
                Physics.gravity = new Vector3(0, -20, 0);
                Destroy(myFirstFlute, 0.5f);
                Destroy(mySecondFlute, 0.5f);
                knifeSound.Play();
                //if (myRay.GetComponent<AudioSource>().isPlaying)
                //{
                //    myRay.GetComponent<AudioSource>().Stop();
                //}
                //PlaySound(knifeSound);

                Destroy(rayGameObject, 0.2f);
                isHit = false;
            }


        }
        else
        {
            isRay = false;
        }
       
    }
    //void PlaySound(AudioClip audio)
    //{
    //    if (myRay.GetComponent<AudioSource>().isPlaying)
    //    {
    //        AudioSource.PlayClipAtPoint(audio, new Vector3(0, 0, -10));
    //    }
    //}
}
