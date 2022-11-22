using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 40f;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        time = 40f;
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        SetTime();
    }


    void SetTime()
    {
        timeText.text = "Time: " + time.ToString("#.00");
    }
}
