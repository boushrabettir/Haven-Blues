using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    public Inventory playerInventory;

    public Item contents;
    //inside chest
    public bool isOpen;
    //when chest is open, will stay open (later will do saving in between scenes)
    public MySignal raiseItem;
    //stuff to show the text [art 
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && playerInRange)
        {
            if (!isOpen) //!whatever means that it is not equal to it. in this case, we dont want the chest to be open but still get the key again. ONLY ONCE
            {

                //open
                OpenChest();

            } else
            {
                //chest is already open
                AlreadyChestOpen();
            }
           


        }


    }
    public void OpenChest()
    {
        // dialog window opens up
        dialogBox.SetActive(true);
        //dialog text is = to the contexts text within the Objects value
        dialogText.text = contents.itemDesc;
        //add into inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;

        //raise signal to player "idle" animation

        raiseItem.Raise();

        //raise context clue
        contextOff.Raise();

        //set chest to opened (only once)
        isOpen = true;
        anim.SetBool("opened", true);


    }

    public void AlreadyChestOpen()
    {
       
            //dialog is set off
            dialogBox.SetActive(false);
            //raise signal that stops
            raiseItem.Raise();
           contextOff.Raise();
            
        



    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isOpen)
        {
            contextOn.Raise();
            playerInRange = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            contextOff.Raise();
            playerInRange = false;

        }
    }


}
