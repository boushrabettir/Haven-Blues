using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger


}

public class Enemy : Coin
{

    public EnemyState currentState;

    public float health;

    public FloatValue maxHealth;

    public Animator anim;

    public string enemyName;

    public int baseAttack;

    public float moveSpeed;

    public Vector2 homePosition; // Have not used this yet

    public Loottable theLoot;

    public Inventory playerInt;

   
    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Awake()
    {
        health = maxHealth.initialValue;
 
    }


    private void CreateLoot()
    {

        if(theLoot != null)
        {
            PowerUps current = theLoot.LootPower();
            //if loottable exists
             if(current != null)
             {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);

             }

        }

    }


    private void TakeDamageCo(float damage)
    {

        health -= damage;
        if (health <= 0)
        {
            anim.SetBool("dead", true);
          
            StartCoroutine(TakeDamageCo());
            

        }

    }

    IEnumerator TakeDamageCo()
    {

        yield return new WaitForSeconds(0.4f);
        CreateLoot();
        this.gameObject.SetActive(false);
        playerInt.enemy += 1;
        powerupSignal.Raise();

    }





    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamageCo(damage);

    }





    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;

        }
    }

}

