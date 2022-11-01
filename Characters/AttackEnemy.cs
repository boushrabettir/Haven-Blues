using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Log
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void CheckDistance()
    {
        if (Vector2.Distance(target.position,
                     transform.position) <= chaseRadius

                && Vector2.Distance(target.position, transform.position) > attackRadius)

        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                thisRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                

            }

        }
        else if (Vector2.Distance(target.position, transform.position) <= chaseRadius
                && Vector2.Distance(target.position, transform.position) <= attackRadius)
            {
            if (currentState == EnemyState.walk && currentState != EnemyState.stagger)
                 {
                    StartCoroutine(AttackingCo());
                 }


            }
    }

    public IEnumerator AttackingCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(0.5f);
        currentState = EnemyState.walk;
        anim.SetBool("attacking", false);
    }


}
