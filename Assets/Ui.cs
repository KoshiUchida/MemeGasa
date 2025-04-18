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
        //StartCoroutine(ShowTutorial());
        X = 0;

    }

    private void Update()
    {
        X = Camera.GetComponent<CameraManager>().GetIndex();
        ShowText(X);


    }


    private void ShowText(int y)
    {
        switch (y)
        {
            case 0:

                tutorialText.text = "���ֈړ����E�ֈړ���";
                Debug.Log("���E");
                textBox.SetActive(true);


                break;

            case 1:

                tutorialText.text = "���L�[�Ŕ��ړ�";
                Debug.Log("hako");
                textBox.SetActive(true);

                break;

            case 2:

                tutorialText.text = "E�L�[�ŃZ�[�u";
                Debug.Log("�X�|�[��");
                textBox.SetActive(true);

                break;




        }

    }
}
