using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary; //binary files where players cannot modify
using System.IO; // input output 
// we can begin save and load up methods

public class DataControl : MonoBehaviour
{

    //will contain data and keep it from scene to scene is the point of this script
    public static DataControl controlling; //public static reference that doesnt equal anything until built upon it
    /// </summary>
    public float unreadMessages;
    public float missedCalls;
    public Button messagesButton;
    public GameObject messagesTemplate;



    // Start is called before the first frame update
    void Awake()
    {

        //awake happens before start
        if (controlling == null)
        {
            DontDestroyOnLoad(gameObject);
            controlling = this;

        }
        else if (controlling != this)
        { // if it exists and this is not it
            // if one game control exists, but it isnt "this" we destroy it because we dont need more than one game control
            Destroy(gameObject);

        }
    }

    

    public void ButtonsOnClick()
    {
        messagesButton.onClick.AddListener(Update);
    }

    void Update()
    {
        if (messagesTemplate.activeInHierarchy)
        {
            messagesTemplate.SetActive(false);
            transform.position = new Vector2(0, 5);
        } else
        {
            transform.position = new Vector2(0, 10) * Time.deltaTime;
            messagesTemplate.SetActive(true);
            
        }
       
    }

    //ongoing method to show stuff on screen
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 130, 30), "Unread Messages: " + unreadMessages);
        GUI.Label(new Rect(10, 30, 100, 30), "Missed Calls: " + missedCalls);
         
    }

    public void Saving()
    {
        //inputing the data writing

        //will save the data out to a file
        //create a file and push the data to it
        BinaryFormatter writer = new BinaryFormatter(); // creating a new binary formatter to encrypt data into its file
        FileStream filesaver = File.Create(Application.persistentDataPath + "/callsAndTexts.dat"); // were not opening, were creatign

        TheData data = new TheData();
        data.messages = unreadMessages; // the data.messages is referencing the class and is equalling it to the local "messages" in this case unreadMessafes of this class
        data.calls = missedCalls;
        // now we write this into the file
        writer.Serialize(filesaver, data); // so it will take the data and write it into the binary filesaver and we reference writer to encrypt it
        filesaver.Close(); //then we close the data

    }
    

    public void LoadIn()
    {
        //outputting the data reading


        //will load in data 
        //need to make sure the file exists then load in 
        //if doesnt exist, and we still run it, then an expception error wil lhappen

        if(File.Exists(Application.persistentDataPath + "/callsAndTexts.dat"))
        { // if it exists then we will go through the process again

            BinaryFormatter writer = new BinaryFormatter();
            FileStream filesaver = File.Open(Application.persistentDataPath + "/callsAndTexts.dat", FileMode.Open); //  we know it already exists so we jjust opening it
            TheData data = (TheData)writer.Deserialize(filesaver); // were pulling out the file but as an object, but we dont necessarily know what that open is 
            // so it pulls it out but it doesnt know what it (the object) is, so we need to tell it what it is by code
            //now by adding (TheData), we will be able to cast that object into TheData , allowing us to pull out the data from the file
            filesaver.Close();

            unreadMessages = data.messages;
            missedCalls = data.messages;
        }
    }


}

[Serializable] //tells unity I can save this class into a specific file
class TheData
{
    public float messages;
    public float calls;


}