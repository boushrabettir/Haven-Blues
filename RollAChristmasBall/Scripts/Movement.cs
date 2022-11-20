using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float moveX;
    private float moveY;
    public float speed;
    public GameObject collectable;
    public GameObject minusCollectable;
    public GameObject boost;
    public Text score;
    private int scorecounter;
    public GameObject gameOver;
    public GameObject gameWin;
    private Vector3 positionOriginal;
    
    

    // Start is called before the first frame update
    void Start()
    {
        positionOriginal = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rigidbody = GetComponent<Rigidbody>();
        scorecounter = 0;
        SetCount();

        //adding in force 
    }
    
    void Update()
    {
        GameOver();
        GameWin();
    }
 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            scorecounter += 1;
            SetCount();
        }

        if (other.gameObject.CompareTag("minus"))
        {
            other.gameObject.SetActive(false);
            scorecounter -= 1;
            SetCount();
        }

        if (other.gameObject.CompareTag("boost"))
        {
            other.gameObject.SetActive(false);
            scorecounter += 3;
            SetCount();
        }

    }

    void OnMove(InputValue movement)
    {
        Vector2 movementVector = movement.Get<Vector2>();
        //gets vector 2 data from inputvalue
        moveX = movementVector.x;
        moveY = movementVector.y;


    }

    void FixedUpdate()
    {
        Vector3 moving = new Vector3(moveX, 0.0f, moveY);
        //0.0 is there bc it is a float value
        rigidbody.AddForce(moving * speed);
    }


    void SetCount()
    {
        score.text = "Score: " + scorecounter.ToString();
       
 
    }


    void GameOver()
    {
        if (scorecounter < 0)
        {
            gameOver.SetActive(true);
            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        /*  if (Input.GetButtonDown("Jump"))
            {
                gameOver.SetActive(false);
                gameObject.transform.position = positionOriginal;
            }

            */
        }

    }

    void GameWin()
    {
        if (scorecounter == 8)
        {
            gameWin.SetActive(true);
            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

    }
  
}
