using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Text titleText;
    private Image darkTitle;
    private Image corlorTitle;
    private Button newButton;
    private Button continueButton;
    public Canvas mainCanvas;

    private bool menuIsActive;
    private bool isChanging;

    // Start is called before the first frame update
    void Start()
    {
        menuIsActive = false;
        isChanging = false;
        darkTitle = mainCanvas.transform.Find("title1").GetComponent<Image>();
        corlorTitle = mainCanvas.transform.Find("title2").GetComponent<Image>();
        newButton = mainCanvas.transform.Find("New").GetComponent<Button>();
        continueButton = mainCanvas.transform.Find("Continue").GetComponent<Button>();

    darkTitle.transform.gameObject.SetActive(true);
        corlorTitle.transform.gameObject.SetActive(false);
        StartCoroutine(BlinkText());
    }

    // Prints number of fingers touching the screen
    void Update()
    {

        if(Input.touches.Length > 0)
        {
            //  titleText.text = "User has " + Input.touches.Length;
            if (!isChanging) { 
                StartCoroutine(ToggleMenu());
            }
        }
      
    }

    IEnumerator ToggleMenu()
    {
        isChanging = true;

        if (!menuIsActive)
        {
            darkTitle.transform.gameObject.SetActive(false);
            corlorTitle.transform.gameObject.SetActive(true);
            titleText.transform.gameObject.SetActive(false);
            newButton.transform.gameObject.SetActive(true);
            continueButton.transform.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        isChanging = false;
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

            titleText.text = "Presione aqui para comenzar";
            yield return new WaitForSeconds(.5f);
        }
    }
}