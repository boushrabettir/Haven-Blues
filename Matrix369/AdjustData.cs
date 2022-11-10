using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdjustData : MonoBehaviour
{

    //singleton design pattern

    void OnGUI()
    {
        //creates buttons that will do everything
        //we can reference DataControl
        if (GUI.Button(new Rect(10, 100, 150, 30), "New Unread Messages"))
        {
            DataControl.controlling.unreadMessages += 2; //refereced it from other script
        }

        if (GUI.Button(new Rect(10, 130, 100, 30), "Missed Calls"))
        {
            if (DataControl.controlling.ButtonsOnClick() && DataControl.controlling.unreadMessages >= 1)
            {
                DataControl.controlling.missedCalls -= 1;
            } else
            {
                // if unread messages were 0, then no need to subtract number
                DataControl.controlling.missedCalls += 0;
            }

        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Save"))
        {
            DataControl.controlling.Saving();
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "Load"))
        {
            DataControl.controlling.LoadIn();
        }
    }
   
}
