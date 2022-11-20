using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //we want the pick up rotaote object to rotate

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
        
    }

   
}
