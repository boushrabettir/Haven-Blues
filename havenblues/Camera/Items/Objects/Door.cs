using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorType
{

    key,
    //must have a key
    enemy,
    //enemies must be killed before entering
    button,
    //switch door

}
public class Door : Interactable
{

    [Header("door variables")]
    public DoorType theDoorType;
    public bool open = false;
    public Inventory playerInv;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollid;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerInRange && theDoorType == DoorType.key)
            {
                //does player have key, and if so open method
                if(playerInv.numberOfKeys > 0)
                {

                    // call open method
                    //remove a player key too
                    playerInv.numberOfKeys--;
                    Open();



                }

            }
        }
    }

    public void Open()
    {

        //do animation
        anim.SetBool("opened", true);
       // anim.SetBool("idleopen", true);
        open = true;
        //turn off the box collider too
        physicsCollid.enabled = false;
        contextOff.Raise();



    }


    public void Closed()
    {

        


    }
}

