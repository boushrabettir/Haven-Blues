using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<pot>().Smash();
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();

            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(collision.gameObject.CompareTag("Player"))
                {
                    if (collision.GetComponent<TestMovement>().currentState != PlayerState.stagger)
                    {
                        Debug.Log("knockback");
                      

                        hit.GetComponent<TestMovement>().currentState = PlayerState.stagger;
                        collision.GetComponent<TestMovement>().Knock(knockTime, damage);

                    }
                }

            }
        }
    }

}
