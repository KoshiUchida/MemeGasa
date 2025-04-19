using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaUIController : MonoBehaviour
{
    public GameObject umbrella;
    public SpriteRenderer spriteRenderer;
    public Sprite State3;
    public Sprite State2;
    public Sprite State1;
    public Sprite State0;


    int umbrellaDurability = 0;

    // Start is called before the first frame update
    void Start()
    {
        umbrella = GameObject.Find("Umbrella(1)_0");

    }

    // Update is called once per frame
    void Update()
    {
        //ŽP‚Ì‘Ï‹v‚ðŽæ“¾
        umbrellaDurability = umbrella.GetComponent<UmbrellaController>().GetDurability();

        ChangeUI();
    }

    void ChangeUI()
    {
        switch (umbrellaDurability)
        {
            case 3:
                spriteRenderer.sprite = State3;
                break;

            case 2:
                spriteRenderer.sprite = State2;
                break;

            case 1:
                spriteRenderer.sprite = State1;
                break;

            default:
                spriteRenderer.sprite = State0;
                break;

        }
    }
}
