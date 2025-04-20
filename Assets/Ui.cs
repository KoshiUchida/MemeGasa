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

                //tutorialText.text = "���ֈړ����E�ֈړ���";
                //Debug.Log("���E");
                //textBox.SetActive(true);
                message = "���ֈړ����E�ֈړ���";
                break;

            case 1:

                //tutorialText.text = "���L�[�Ŕ��ړ�";
                //Debug.Log("hako");
                //textBox.SetActive(true);
                message = "���L�[�Ŕ��ړ�";

                break;

            case 2:

                //tutorialText.text = "���ɔ��𗎂Ƃ��Đi��";
                //Debug.Log("�X�|�[��");
                //textBox.SetActive(true);
                message = "���ɔ��𗎂Ƃ��Đi��";

                break;
            case 3:
                message = "���L�[�Ŗ؂�|��";

                break;
            case 4:
                message = "���L�[�ł͂�����o��\n�o���Ă��Ԃŏ�L�[�ł͂���������";


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

        //�ӂ��[�ǂ���
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
