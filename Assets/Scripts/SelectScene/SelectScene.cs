using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite State1;
    public Sprite State2;
    public Sprite State3;

    int selectNumber;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = State1;
        selectNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

        SelectPlayScene();

        if (selectNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TutorialScene");
            }

        }
        else if (selectNumber == -1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameplayScene");
            }
        }

    }


    void SelectPlayScene()
    {
        //ステージ2へ
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectNumber == 0 || selectNumber == -1)
            {

                selectNumber = 1;
                spriteRenderer.sprite = State2;
            }
        }
        //ステージ1へ
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectNumber == 0 || selectNumber == 1)
            {
                selectNumber = -1;
                spriteRenderer.sprite = State3;
            }
        }

    }

}
