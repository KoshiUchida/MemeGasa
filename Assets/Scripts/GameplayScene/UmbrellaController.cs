using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public GameObject player;

    public SpriteRenderer spriteRenderer;
    public Sprite Open;
    public Sprite Close;

    AudioSource audioSource;
    public AudioClip OpenSound;
    public AudioClip CloseSound;


    int Durability = 3;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�摜�؂�ւ�
        ChangeSprite();

        //�P�K�[�h
        UmbrellaGuard();
    }

    void ChangeSprite()
    {
        switch (Durability)
        {
            case 3:
                UmbrellaSprite();
                break;

            case 2:
                UmbrellaSprite();
                break;

            case 1:
                UmbrellaSprite();
                break;

            default:
                spriteRenderer.sprite = null;
                break;
        }
    }

    public void TakeDamage()
    {
        Durability -= 1;
    }

    void Guard()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.tag = "Guard";
            
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Umbrella";
            
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(OpenSound);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(CloseSound);
        }
    }

    //�P�̑ϋv
    void UmbrellaGuard()
    {

        switch (Durability)
        {
            case 3:
                //�h��
                Guard();
                break;

            case 2:
                //�h��
                Guard();
                break;

            case 1:
                //�h��
                Guard();
                break;

            case 0:
                Debug.Log("�P�̑ϋv�������Ȃ���");
                this.tag = "Umbrella";
                break;

            default:
                break;
        }
    }

    void UmbrellaSprite()
    {
        if (player.tag == "Guard")
        {
            spriteRenderer.sprite = Open;
        }
        else
        {
            spriteRenderer.sprite = Close;
        }
    }

    public int GetDurability()
    {
        return Durability;
    }

    public void Reset()
    {
        Durability = 3;
    }
}
