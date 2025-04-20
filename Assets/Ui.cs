using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
using TMPro;
using System.Timers;

public class Ui : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text tutorialText;
    public GameObject Camera;
    
    //
    public float fadeDuration = 1.0f;
    public float displayDuration = 2.0f;

    public int X;
    //
    private int lastIndex = -1;
    private Coroutine fadeCoroutine;


    private void Start()
    {
        X = 0;
        textBox.SetActive(true);
        //

    }

    private void Update()
    {
        X = Camera.GetComponent<CameraManager>().GetIndex();
        //ShowText(X);
        //

        if( X != lastIndex)
        {
            lastIndex = X;
            ShowText(X);
        }

    }


    private void ShowText(int y)
    {
        string message = "";

        switch (y)
        {
            case 0:

                //tutorialText.text = "左へ移動←右へ移動→";
                //Debug.Log("左右");
                //textBox.SetActive(true);
                message = "左へ移動←右へ移動→";
                break;

            case 1:

                //tutorialText.text = "↑キーで箱移動";
                //Debug.Log("hako");
                //textBox.SetActive(true);
                message = "↑キーで箱移動";

                break;

            case 2:

                //tutorialText.text = "穴に箱を落として進む";
                //Debug.Log("スポーン");
                //textBox.SetActive(true);
                message = "穴に箱を落として進む";

                break;
            case 3:
                message = "↑キーで木を倒す";

                break;
            case 4:
                message = "↑キーではしごを登る\n登ってる状態で上キーではしごを下る";


                break;

            default:
                return;
        }


        if(fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        tutorialText.text = message;
        fadeCoroutine = StartCoroutine(FadeRoutine());


    }
   

    private IEnumerator FadeRoutine()
    {
        textBox.SetActive(true);

        Color c = tutorialText.color;
        c.a = 0;
        tutorialText.color = c;

        //ふぇーどいん
        float elapsed = 0f;

        while(elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            tutorialText.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(displayDuration);

    }


}
