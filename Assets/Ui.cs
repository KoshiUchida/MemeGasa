using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text tutorialText;

    private void Start()
    {
        StartCoroutine(ShowTutorial());
    }


    private IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(1f);

        tutorialText.text = "ç∂Ç÷à⁄ìÆÅ©âEÇ÷à⁄ìÆÅ®";
        textBox.SetActive(true);

        yield return new WaitForSeconds(200f);

        textBox.SetActive(false);
    }

   
}
