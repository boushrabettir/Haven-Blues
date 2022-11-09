using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject signHolder;
    public Text signText;
    private int position;
    public Button buttonctn;
    public bool playerInRange;





 
  

   void Awake() {
        buttonctn.onClick.AddListener(Clicked);


    }

    void Clicked()
    {
        signHolder.SetActive(false);
   

    }
   

    // Update is called once per frame
   public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.O) && playerInRange)
        {
            if (signHolder.activeInHierarchy)
            {
                signHolder.SetActive(false);
    
                    

            }
            else
            {
                signHolder.SetActive(true);
                Awake();


            }
        }

     
      


    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

        }
    }

}
