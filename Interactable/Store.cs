using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : PowerUps
{

    
    public Inventory playerInt;
    public Button bookButton;
    public MySignal coinDeduct;






    // Start is called before the first frame update
    void Start()
    {

        coinDeduct.Raise();
        

    }

    // Update is called once per frame
    public void Update()
    {

        OnClick();

    }

    public void OnClick()
    {
        bookButton.onClick.AddListener(clicked);

    }



    public void clicked()
    {

        playerInt.coins -= 3;
        coinDeduct.Raise();
        

    }



}
