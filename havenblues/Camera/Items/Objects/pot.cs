using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : Interactable
{


    private Animator anim;
    private Collider2D collision;

    


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
      
        
        
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    public void Smash()
    {
       
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
        

        Debug.Log("Did");
        
    }

    IEnumerator breakCo()
    {

        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);


    }

}
