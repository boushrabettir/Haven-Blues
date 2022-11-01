using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;

    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator animator;

    public float damage;

    public FloatValue currentHealth;

    


    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();



    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }



    private void FixedUpdate()
    {
        //if movement is not 0 try to move
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if(!success && movementInput.x > 0)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                
            }

            if (!success && movementInput.y > 0)
            {
                _ = TryMove(new Vector2(0, movementInput.y));
            }


            animator.SetBool("isMoving", success);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        //Set direction of sprite to movement direction
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }


    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
              direction,
              movementFilter,
              castCollisions,
              moveSpeed * Time.fixedDeltaTime + collisionOffset);


        if (count == 0)
        {
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
            return true;
       
        } else
        {
            return false;
        }


    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy2")
        {
            //Dealing damage

            Enemy2 enemy2 = other.GetComponent<Enemy2>();

            if(enemy2 !=null)
            {
                enemy2.Health -= damage;


            }
        }
    }
}

