using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : Timer
{

    public GameObject coins;
    public GameObject boostCoins;
    private int coinCounter;
    public Text coinCounterText;
    public GameObject coinDisplay;
    public GameObject coinDisplayBoost;
    public Button coinBackgroundInv;
    public Button coinBackgroundBoost;
    private int coinInvCounter;
    private int boostCoinInvCounter;
    public Text coinInvText;
    public Text boostCoinInvText;
    public GameObject boxYellow;
    public GameObject boxBlue;
    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        coinInvCounter = 0; //our regular coin inv
        boostCoinInvCounter = 0; //our boost coin inv
        coinDisplay.SetActive(false);
        coinBackgroundInv.gameObject.SetActive(false);
        coinDisplayBoost.SetActive(false);
        coinBackgroundBoost.gameObject.SetActive(false);
        OnTextScreen();

        coinBackgroundInv.onClick.AddListener(AddTime);
        coinBackgroundBoost.onClick.AddListener(AddTimeBoost);


    }


    public void AddTime()
    {
        if (coinInvCounter > 0)
        {
            time += 3f;
            coinInvCounter -= 1;
            OnTextScreen();

        }
        else
        {
            time += 0f;
            coinInvCounter += 0;
            OnTextScreen();
        }

    }

    public void AddTimeBoost()
    {
        if (boostCoinInvCounter > 0)
        {
            time += 7f;
            boostCoinInvCounter -= 1;
            OnTextScreen();

        }
        else
        {
            time += 0f;
            boostCoinInvCounter += 0;
            OnTextScreen();
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("regular"))
        {
            coinCounter += 1;
            coinInvCounter += 1;
            coinDisplay.SetActive(true);
            boxYellow.GetComponent<Image>().color = new Color32(128, 111, 13, 255);
            coinBackgroundInv.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            OnTextScreen();

        }

        if (collision.gameObject.CompareTag("boost"))
        {
            coinCounter += 3;
            boostCoinInvCounter += 1;
            coinDisplayBoost.SetActive(true);
            boxBlue.GetComponent<Image>().color = new Color32(16, 23, 128, 225);
            coinBackgroundBoost.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            OnTextScreen();
        }
    }

    void OnTextScreen()
    {
        coinCounterText.text = "Total points: " + coinCounter.ToString();
        coinInvText.text = coinInvCounter.ToString();
        boostCoinInvText.text = boostCoinInvCounter.ToString();
    }
}
