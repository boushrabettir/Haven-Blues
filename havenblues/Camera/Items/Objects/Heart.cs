using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUps
{

    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountIncrease;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerHealth.RuntimeValue += amountIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;


            }
            powerupSignal.Raise();
            Destroy(this.gameObject);


        }

    }
}
