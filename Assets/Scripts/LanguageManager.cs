using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LanguageManager : MonoBehaviour
{
    public Text titleText;
    public Button englishBtn;
    public Button spanishBtn;
    private string selectedLanguage;


    void Start()
    {
        selectedLanguage = GetSavedLanguage();

        if (selectedLanguage == "")
        {
            englishBtn.onClick.AddListener(() =>
            {
                ChangeLanguage("en");
            });

            spanishBtn.onClick.AddListener(() =>
            {
                ChangeLanguage("es");
            });

            StartCoroutine(BlinkText());
        }
        else
        {
            Debug.Log("Language already selected " + selectedLanguage);
            SceneManager.LoadScene("Title");
        }
       
    }

    void ChangeLanguage(string language)
    {
        Debug.Log("You have clicked the button " + language);

        // save the language to preferences
        try
        {
            PlayerPrefs.SetString("language", language);
            SceneManager.LoadScene("Title");
        }

        // handle the error
        catch (System.Exception err)
        {
            Debug.Log("Error trying to save the language: " + err);
        }
    }

    private string GetSavedLanguage()
    {

        string language = "";
        // save the language to preferences
        try
        {
            language = PlayerPrefs.GetString("language");
        }

        // handle the error
        catch (System.Exception err)
        {
            Debug.Log("Error triying to get the language: " + err);
        }

        return language;
    }

    //function to blink the text
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            titleText.text = "Select your language";
            yield return new WaitForSeconds(3f);

            titleText.text = "Elige tu idioma";
            yield return new WaitForSeconds(3f);
        }
    }
}
