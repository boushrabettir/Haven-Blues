using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : Interactable
{

    public GameObject shopBackground;

    
  


    // Start is called before the first frame update
    void Start()
    {

       

    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerInRange)
        {
            if (shopBackground.activeInHierarchy)
            {
                shopBackground.SetActive(false);
            }
            else
            {
                shopBackground.SetActive(true);
             
                
            }
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            
        }
    }









}
