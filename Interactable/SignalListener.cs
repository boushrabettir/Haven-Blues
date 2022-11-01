using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{


    public MySignal mySignal;
    public UnityEvent signalEvent;


    public void OnSignalRaised()
    {

        signalEvent.Invoke();

    }

    private void OnEnable()
    {
        mySignal.RegisterListener(this);
    }

    private void OnDisable()
    {
        mySignal.DeRegisterListener(this);
    }


}
