using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infobox : MonoBehaviour {

    public string text;
    public int windowWidth;
    public int windowHeight;

    public string thumbnail;
    public bool display = false;
    public bool thumbnailbool = false;
    

    // Use this for initialization
    void Start () {
        thumbnail = "Korte informatie wordt getoond \n \n" + thumbnail + "\n \n Druk op i voor meer informatie";
        text = "Uitgebreide informatie wordt getoond \n \n" + text + "\n \n Druk op i voor minder informatie";
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("i") && thumbnailbool)
        {
            display = !display;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thumbnailbool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            thumbnailbool = false;
            display = false;
        }
    }

    private void OnGUI ()
    {
        if (thumbnailbool && display == false)
        {
            GUI.TextArea(new Rect((Screen.width - 300) / 2, (Screen.height - 150) / 2, 300, 150), thumbnail);
        }

        if (thumbnailbool && display)
        {
            GUI.TextArea(new Rect((Screen.width - windowWidth) / 2, (Screen.height - windowHeight) / 2, windowWidth, windowHeight), text);
        }
    }
}
