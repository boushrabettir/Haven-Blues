using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUps
{

    public Inventory playerInv;
    
    


    // Start is called before the first frame update
    void Start()
    {

        powerupSignal.Raise();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInv.coins += 1;
            powerupSignal.Raise();
            
            Destroy(this.gameObject);


        }
        

    }





}
