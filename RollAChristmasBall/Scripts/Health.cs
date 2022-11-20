using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public GameObject spikes;
    private int health;
    public Text healthText;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100;
        HealthShow();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            health -= 3;
            anim.SetBool("hit", true);
            HealthShow();
            anim.SetBool("hit", false);
        }
    }

    void HealthShow()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
