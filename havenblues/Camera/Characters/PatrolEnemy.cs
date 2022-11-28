using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Log
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;



    public override void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector2.Distance(target.position, transform.position) > attackRadius)

        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                thisRigidBody.MovePosition(temp);
                //ChangeState(EnemyState.walk); it will never change state bc this enemy will continue to walk without stopping hence the name
                
                anim.SetBool("wakeUp", true);

            }

        }
        else if (Vector2.Distance(target.position,
                    transform.position) > chaseRadius)
        {
            
                if (Vector2.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                thisRigidBody.MovePosition(temp);

            }else
            
            {

                ChangePath();
            }

        }
    }

    private void ChangePath()
    {
        if(currentPoint == path.Length - 1)
        {

            currentPoint = 0;
            currentGoal = path[0];

        } else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }


    }


}
