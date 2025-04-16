using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaTest : MonoBehaviour
{
    //int
    int umbrellaHp;

    GameObject damage;

    // Start is called before the first frame update
    void Start()
    {
        //�P�̑ϋv��ݒ�
        umbrellaHp = 30;

        damage = GameObject.Find("Umbrella");
    }

    // Update is called once per frame
    void Update()
    {
        umbrellaHp = damage.GetComponent<Damage>().GetHealth();

        //�h��
        //Guard();

        //�P�̑ϋv
        Durability();

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
    }

    //�P�̑ϋv
    void Durability()
    {

        switch (umbrellaHp)
        {
            case 30:
                //�h��
                Guard();
                break;

            case 20:
                //�h��
                Guard();
                break;

            case 10:
                //�h��
                Guard();
                break;

            case 0:
                Debug.Log("�P�̑ϋv�������Ȃ���");
                break;

            default:
                break;
        }
    }
}
