using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTran : Sign
{

    
   //ublic GameObject fadeDarkPanel; //in
  //public GameObject fadeOutPanel; // out
    public float fadeTime;
    public Text loadingText;
    public string[] loadingSentences;
    private int position;
    public float wordSpeed;
    public int scene;
    
   
    public void Awake()
    {
        buttonctn.onClick.AddListener(clicked);
    }

    public void clicked()
    {
        StartCoroutine(Loading());

    }
    
    IEnumerator Loading()
    {
        yield return Texting();
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        
    }



   IEnumerator Texting()
    {

        foreach (char letter in loadingSentences[position].ToCharArray()){
            loadingText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        
        }

        yield return null;
    }
}
