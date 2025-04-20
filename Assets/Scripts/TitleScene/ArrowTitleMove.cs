using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowTitleMove : MonoBehaviour
{
    public RectTransform[] selectedPosition;
    public int selectedIndex = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedPosition.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex >= selectedPosition.Length)
            {
                selectedIndex = 0;
            }
        }

        this.GetComponent<RectTransform>().position = selectedPosition[selectedIndex].position;
    }
}
