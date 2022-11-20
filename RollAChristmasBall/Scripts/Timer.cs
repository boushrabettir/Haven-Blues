using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour

{
    public float time = 30f;
    public Text timeText;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        time = 30f;
        SetTime();
        
    }

 
    // Update is called once per frame
    void Update()
    {
        time -=Time.deltaTime;
       SetTime();
        if (time <= 0f)
        {
            gameOver.SetActive(true);
        }
    
     
    }


    void SetTime()
    {
        timeText.text = "Time: " + time.ToString("#.00");
    }
}


