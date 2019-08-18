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

        selectedLanguage = I18n.GetPreferredLanguage();

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

    // Change the global language for the game
    private void ChangeLanguage(string language)
    {
        I18n.ChangePreferredLanguage(language);
        SceneManager.LoadScene("Title");
    }
}
