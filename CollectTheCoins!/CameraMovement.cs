using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject carPlayer;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - carPlayer.transform.position;       
    }

    // Smooth camera movement
    // Move camera after the vechile has been moved
    void LateUpdate()
    {
        transform.position = carPlayer.transform.position + offset;
    }
}
