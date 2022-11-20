using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //must be calculated immeditable when it starts once
        offset = transform.position - player.transform.position;
        //create a offset for the camera


        
    }

    // Update is called once per frame
    // late update will happen when all the other updates will hapepnn
    void LateUpdate() 
    {
        //to follow the player
        transform.position = player.transform.position + offset;

        


    }
}
