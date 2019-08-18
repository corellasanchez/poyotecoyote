using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    private List<Image> images;
    private List<string[,]> subtitles;
    private string[] imageNames;
    private float fadeSpeed;
    public Canvas mainCanvas;
    public GameObject subsText;
    public AudioSource introMusic;

    // Start is called before the first frame update
    void Start()
    {
        InicializeScene();
        StartCoroutine(PlayIntro());
    }

    private void Update()
    {
        //if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
        //{
        //    skipIntro();
        //}
    }

    private void skipIntro()
    {
            try
            {
                PlayerPrefs.SetInt("oldPlayer", 1);
                SceneManager.LoadScene("MovementTest");
            }
            catch (System.Exception err)
            {
            Debug.Log("Error triying skip the intro " + err);
            }
    }

    // You can use it for multiple images, just pass that image.
    IEnumerator Fadeout(Image image, float speed)
    {

        // Will run only until image's alpha becomes completely 0, will stop after that.
        while (image.color.a > 0)
        {
            // You can replace WaitForEndOfFrame with WaitForSeconds.
            yield return new WaitForEndOfFrame();
            Color colorWithNewAlpha = image.color;
            colorWithNewAlpha.a -= speed;
            image.color = colorWithNewAlpha;
        }

        image.transform.gameObject.SetActive(false);
    }

    IEnumerator PlayIntro()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.gameObject.SetActive(true);
            
            for (int y = 0; y < subtitles[i].GetLength(0); y++)
            {
                subsText.GetComponent<Text>().text = subtitles[i][y, 0];
                yield return new WaitForSeconds(int.Parse(subtitles[i][y, 1], System.Globalization.NumberStyles.Integer));
            }
            subsText.GetComponent<Text>().text = "";
            StartCoroutine(Fadeout(images[i], fadeSpeed));
        }
        

        try
        {
            introMusic.Stop();
            PlayerPrefs.SetInt("oldPlayer", 1);
            SceneManager.LoadScene("MovementTest");
        }
        catch (System.Exception err)
        {
            Debug.Log("Error triying skip the intro " + err);
        }
    }

    void InicializeScene()
    {
        fadeSpeed = 0.05f;
        imageNames = new string[]{ "intro1","intro2","intro3"};
        images = new List<Image>();
        subtitles = new List<string[,]>();

        foreach (string imageName in imageNames)
        {
            images.Add(mainCanvas.transform.Find(imageName).GetComponent<Image>());
        }
        
        string[,]  subs1  = new string[,]{
             { I18n.Fields["intro1"], "2"},
             { I18n.Fields["intro2"], "2" },
             { I18n.Fields["intro3"], "3"},
         };

        subtitles.Add(subs1);

        string[,] subs2 = new string[,]{
             { I18n.Fields["intro4"], "2"},
             { I18n.Fields["intro5"], "3"},
              { I18n.Fields["intro6"], "3"},
         };

        subtitles.Add(subs2);

        string[,] subs3 = new string[,]{
             { I18n.Fields["intro7"], "3"},
             { I18n.Fields["intro8"], "3" },
         };

        subtitles.Add(subs3);
    }

}
