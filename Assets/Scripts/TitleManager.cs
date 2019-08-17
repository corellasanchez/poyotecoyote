using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    // Load a new game or a saved game.
    void Update()
    {
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
        {
            int oldPlayer = 0;

            try
            {
                oldPlayer = PlayerPrefs.GetInt("oldPlayer");
            }
            catch (System.Exception err)
            {
                Debug.Log("Error triying to get the language: " + err);
            }
            
            if (oldPlayer == 0)
            {   // Show intro to the new player
                SceneManager.LoadScene("Intro");
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //function to blink the text
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            titleText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);

            titleText.text = I18n.Fields["pressToContinue"];
            yield return new WaitForSeconds(.5f);
        }
    }
}