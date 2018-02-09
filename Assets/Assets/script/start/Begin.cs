using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {
    public GUISkin mySkin;
    public AudioSource audioSource;
    bool isSound1 = true;
    bool isSound2 = false;

    void Start()
    {
    }
    void OnGUI()
    {
        GUI.skin = mySkin;
        if(GUI.Button(new Rect(480, 180, 220, 66), "", GUI.skin.GetStyle("Play")))
            SceneManager.LoadScene("Game");
        if (GUI.Button(new Rect(480, 250, 220, 66), "", GUI.skin.GetStyle("More")))
            Application.OpenURL("https://lbv.github.io/litjson");
        if (isSound1)
        {
            if (GUI.Button(new Rect(200, 400, 26, 31), "", GUI.skin.GetStyle("Sound1")))
            {
                audioSource.Play();
                isSound1 = false;
                isSound2 = true;
            }
        }
        if (isSound2)
        {
            if (GUI.Button(new Rect(200, 400, 26, 31), "", GUI.skin.GetStyle("Sound1")))
            {
                audioSource.Stop();
                isSound1 = true;
                isSound2 = false;
            }
        }

    }
}
