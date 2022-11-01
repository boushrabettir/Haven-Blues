using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

   public Enemy[] enemies; // thats an array -- will learn more in school --
    public pot[] pots;// array of pots
    public GameObject virtualCamera; 
    // when i leave a room , go thru all enemies and pots are inactive, enter room active
    //need observer object to make signal and enemy / pot can set itself inactive
    //observer objects makes stuff active , a signal alone does not make inactive enemies active

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && !collision.isTrigger)
        {

            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
           

            
            //virtual void so can be overried in doors etc.

            virtualCamera.SetActive(true);


        }

    }


    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {

         for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);


            }

                    

            virtualCamera.SetActive(false);
        }


    }


    public void ChangeActivation(Component component, bool activation)
    {

        component.gameObject.SetActive(activation);

    }

}
