using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class TestMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealthNow;
    public MySignal playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer itemRecieveSprite;
    public MySignal playerHit;
    






   


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);


        // transform.position = startingPosition.initialValue;



    }

    // Update is called once per frame
    void Update()
    {

        //is the player in an interaction?
        if (currentState == PlayerState.interact)
        {
            return;

        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");





        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();


        }





    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact) //if im not interacting wiht space then the walk anim will happen
        {
            currentState = PlayerState.walk;
        }


    }

    public void RaiseItem()
    {

        if (playerInventory.currentItem != null) //there is current item, not equal to none
        {
            if (currentState != PlayerState.interact)
            {


                animator.SetBool("recieve", true);
                currentState = PlayerState.interact;
                itemRecieveSprite.sprite = playerInventory.currentItem.spriteItem;
            }
            else
            {
                animator.SetBool("recieve", false);
                currentState = PlayerState.idle;
                itemRecieveSprite.sprite = null;
                playerInventory.currentItem = null;


            }
        }


    }




    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {

            animator.SetBool("moving", false);



        }




    }




    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition
            (

            transform.position + change * speed * Time.deltaTime

            );


    }


    public void Knock(float knockTime, float damage)
    {
        currentHealthNow.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealthNow.RuntimeValue > 0)
        {

            StartCoroutine(KnockCo(knockTime));
            

        }
        else
        {
            this.gameObject.SetActive(false);


        }



    }



    private IEnumerator KnockCo(float knockTime)
    {

        playerHit.Raise(); //raise signal when knockpack happens and camera anim happens
        

        if (myRigidBody != null)
        {


            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;

        }
    }

}
   

