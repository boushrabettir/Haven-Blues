using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMatrix : AnimationSign
{


    public GameObject signHolder;
    public Text signText;
    private int position;
    public float wordSpeed;
    public string[] sentence;
    public bool playerInRange;
    public GameObject contextClue;
    public GameObject endingPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && playerInRange)
        {
            if (signHolder.activeInHierarchy)
            {
                signHolder.SetActive(false);



            }
            else
            {
                signHolder.SetActive(true);
                contextClue.SetActive(false);
                anim.SetBool("clicked", true);
                StartCoroutine(Ending());
                
                
                


            }
        }



    }


    public IEnumerator Ending()
    {
        yield return WordWorking();
        endingPanel.SetActive(true);
    }



    public void NextLineInSentence()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerInRange)
        {

            if (position < sentence.Length - 1)
            {
                position++;
                signText.text = " ";
                StartCoroutine(WordWorking());
                signHolder.SetActive(false);

            }
        }
    }

    public IEnumerator WordWorking()
    {

        foreach (char letter in sentence[position].ToCharArray())
        {

            signText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            contextClue.SetActive(true);

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            contextClue.SetActive(false);

        }
    }

}
