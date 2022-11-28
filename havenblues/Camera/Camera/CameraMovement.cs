using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

   //Changed camera system to the built in Cinematic Unity system

    public Vector2 maxPos;
    public Vector2 minPos;

    public Transform target;
    public float smoothingTime;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingTime);

        }
        
    }


    public void KickGame()
    {
        anim.SetBool("kickon", true);
        StartCoroutine(KickCo());
       

    }

    public IEnumerator KickCo()
    {
        yield return null; //makes it wait one frame
        anim.SetBool("kickon", false);
    }

}
