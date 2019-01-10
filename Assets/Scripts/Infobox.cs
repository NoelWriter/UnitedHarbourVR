using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Infobox : MonoBehaviour
{
    private string FilePath;

    public string ObjectName;
    private string longtext = null;
    private string shorttext = null;
    private bool objectinformation = false;
    private Collider object1;
    private int windowWidth = 500;
    private int windowHeight = 500;

    private bool display = false;
    private bool shorttextbool = false;


    // Use this for initialization
    void Start()
    {
        FileReader();
        object1 = GetComponent<Collider>();
        if (objectinformation && ObjectName != "")
        {
            shorttext = "\nKorte informatie wordt getoond\n\n" + shorttext + "\n\nDruk op i voor meer informatie";
            longtext = "\nUitgebreide informatie wordt getoond\n\n" + longtext + "\n\nDruk op i of loop weg voor minder informatie";
        }
        else
        {
            Debug.Log("No information about object: '" + ObjectName + "' found in: " + FilePath);
            shorttext = "Er is geen informatie over dit object opgegeven.";
            longtext = shorttext;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("i") && shorttextbool)
        {
            display = !display;
        }

        Transform player = GameObject.FindWithTag("Player").transform;
        Vector3 point = object1.ClosestPointOnBounds(player.transform.position);
        float distance2 = Vector3.Distance(point, player.transform.position);
        if (distance2 < 10)
        {
            shorttextbool = true;
        }
        else
        {
            shorttextbool = false;
            display = false;
        }
    }

    void FileReader()
    {
        FilePath = Application.dataPath + "/Resources/ObjectInfo.txt";

        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(ObjectName))
                    {
                        //Turn Bool on, information found.
                        objectinformation = true;
                        shorttext = line.Split(';')[1];
                        longtext = line.Split(';')[2];
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private void OnGUI()
    {
        if (shorttextbool && display == false)
        {
            GUI.TextArea(new Rect((Screen.width - 300) / 2, (Screen.height - 150) / 2, 300, 150), shorttext);
        }

        if (shorttextbool && display && objectinformation)
        {
            GUI.TextArea(new Rect((Screen.width - windowWidth) / 2, (Screen.height - windowHeight) / 2, windowWidth, windowHeight), longtext);
        }
    }
}