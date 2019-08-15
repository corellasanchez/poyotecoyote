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
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
        {
            skipIntro();
        }
    }

    private void skipIntro()
    {
            try
            {
                PlayerPrefs.SetInt("oldPlayer", 1);
                SceneManager.LoadScene("SampleScene");
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
        introMusic.Stop();
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
             { "En el reino de los poyotes"  , "2"},
             { "la vida siempre fue"  , "2" },
             { "feliz y apacible.", "3"},
         };

        subtitles.Add(subs1);

        string[,] subs2 = new string[,]{
             { "Hasta que la barrera protectora"  , "2"},
             { "que defendía el reino, desaparecio", "3"},
              { "los Coyotes comenzaron a atacar el sin piedad...", "3"},
         };

        subtitles.Add(subs2);

        string[,] subs3 = new string[,]{
             { "La única esperanza del reino"  , "3"},
             { "es un pollo rebelde ...."  , "3" },
         };

        subtitles.Add(subs3);
    }

}
