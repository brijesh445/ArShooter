using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startscript : MonoBehaviour
{

 
    public Text HighScoreHolderText;

    private int highscore;

    // Start is called before the first frame update
    void Start()
    {
       highscore = PlayerPrefs.GetInt ("highscore", highscore);
        HighScoreHolderText.text = highscore.ToString();
       
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
     public void LoadScene()
     {
        Debug.Log("hhe");
           SceneManager.LoadScene("SampleScene",  LoadSceneMode.Single);
      }

      public void exit(){
        Application.Quit();
      }
}
