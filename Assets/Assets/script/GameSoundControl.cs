using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundControl : MonoBehaviour
{
    public GUISkin mySkin;
    public bool isSoundButton1=false;
    public bool isSoundButton2 = true;
    [HideInInspector]
    public AudioSource sound;
    // Use this for initialization
    void Start ()
    {
        sound = GetComponent<AudioSource>();

	}
    void OnGUI()
    {
        GUI.skin = mySkin;
        if (isSoundButton1)
        {
            if (GUI.Button(new Rect(12, 430, 20, 31), "", GUI.skin.GetStyle("Sound1")))
            {
                sound.Play();
                isSoundButton1 = false;
                isSoundButton2 = true;
            }
        }
        if (isSoundButton2)
        {
            if (GUI.Button(new Rect(12, 430, 37, 31), "", GUI.skin.GetStyle("Sound2")))
            {
                sound.Stop();
                isSoundButton1 = true;
                isSoundButton2 = false;
            }
        }
       
    }
	// Update is called once per frame
	void Update () {
		
	}
}
