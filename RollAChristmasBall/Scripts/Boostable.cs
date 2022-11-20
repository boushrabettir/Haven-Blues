using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostable : MonoBehaviour
{
    public int speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 50, 25) * speed * Time.deltaTime);
    }
}
