using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{

    public Door[] doors;
    


  


    public void CheckforEnemy()
    {
        //check for enemies in room to activate door

        for(int i =0; i < enemies.Length; i++)
        {

            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {

                //if enemy is still active
                return;

            }

        }

        OpenedDoors();



    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }



            //virtual void so can be overried in doors etc.

            virtualCamera.SetActive(true);


        }

        CloseDoors(); // doors close if enemies arise

    }


    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);


            }



            virtualCamera.SetActive(false);
        }

        OpenedDoors(); // doors open if enemies are dead

    }


    public void CloseDoors()
    {
        //go thru doors in list and set to open to closed

        for(int i =0; i< doors.Length; i++)
        {

            doors[i].Open();

        }



    }

    public void OpenedDoors()
    {

        //int thru doors in list set from closed to open

        for (int i = 0; i < doors.Length; i++)
        {

            doors[i].Closed();

        }
    }

   
}
