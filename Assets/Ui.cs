using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text tutorialText;

    public GameObject Camera;

    public int X;
    private void Start()
    {
        StartCoroutine(ShowTutorial());


    }

    private void Update()
    {
        //X = Camera.GetComponent<CameraManager>().



    }


    private IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(0f);

        tutorialText.text = "���ֈړ����E�ֈړ���";
        Debug.Log("���E");
        textBox.SetActive(true);

        yield return new WaitForSeconds(2f);

        textBox.SetActive(false);
        Debug.Log("������");


        tutorialText.text = "���L�[�Ŕ��ړ�";
        Debug.Log("hako");
        textBox.SetActive(true);

        yield return new WaitForSeconds(7f);

        textBox.SetActive(false);

    }
   
}
