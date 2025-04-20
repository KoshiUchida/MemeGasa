using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowTitleMove : MonoBehaviour
{
    public RectTransform[] selectedPosition;
    public int selectedIndex = 0;

    private AudioSource audioSource;

    public AudioClip moveSE;

    void Start()
    {
        selectedIndex = 0;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (audioSource != null && moveSE != null)
            {
                audioSource.PlayOneShot(moveSE);
            }

            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedPosition.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (audioSource != null && moveSE != null)
            {
                audioSource.PlayOneShot(moveSE);
            }

            selectedIndex++;
            if (selectedIndex >= selectedPosition.Length)
            {
                selectedIndex = 0;
            }
        }

        this.GetComponent<RectTransform>().position = selectedPosition[selectedIndex].position;
    }
}
