using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinTextManage : MonoBehaviour
{

    public Inventory playerInv;
    public Text coinDisplay;



    public void UpdateCoinCount()
    {

        coinDisplay.text = "" + playerInv.coins;


    }

}
